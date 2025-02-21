
using UnityEngine;
using TestTask.UI;

namespace TestTask
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private new Camera camera;

        public static GameController Instance { get; private set; }
        public Camera Camera => camera;

        private void Awake()
        {
            Instance = this;

            EventBus.GameInitialized.AddListener(OnGameInitialized);
        }

        public void GameOver()
        {
            Global.PlayerCharacter.StopMovement();
            Global.UIController.ShowScreen<GameOverScreen>();
        }

        public void LevelComplete()
        {
            Global.PlayerCharacter.StopMovement();
            Global.UIController.ShowScreen<LevelCompleteScreen>();
        }

        private void OnGameInitialized()
        {
            EventBus.GameInitialized.RemoveListener(OnGameInitialized);
            ShowLobby();
        }

        private void ShowLobby()
        {
            var parameters = new LobbyScreen.Parameters()
            {
                GameStarted = StartGame
            };
            Global.UIController.ShowScreen<LobbyScreen>(parameters);

            camera.transform.SetParent(Global.PlayerCharacter.CameraPivot);
            camera.transform.localPosition = Vector3.zero;
            camera.transform.localRotation = Quaternion.identity;
        }

        private void StartGame()
        {
            Global.LevelManager.StartLevel();

            var parameters = new GameplayScreen.Parameters()
            {
                Exit = EndLevel
            };
            Global.UIController.ShowScreen<GameplayScreen>(parameters);
        }

        private void EndLevel()
        {
            camera.transform.SetParent(transform);
            Global.LevelManager.RestartLevel();
            ShowLobby();
        }
    }
}
