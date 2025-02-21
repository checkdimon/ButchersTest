
using UnityEngine;

namespace TestTask.Startup
{
    public class EnterPoint : MonoBehaviour
    {
        private void Awake()
        {
            SetStartupOptions();
        }

        private void Start()
        {
            InitializeGame();
            EventBus.GameInitialized.Invoke();

            Destroy(gameObject);
        }

        private void SetStartupOptions()
        {
            Application.targetFrameRate = 60;
        }

        private void InitializeGame()
        {
            Global.PlayerProgress.Initialize();
            Global.LevelManager.Init();
        }
    }
}