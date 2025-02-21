
using UnityEngine;
using TestTask.Progress;
using TestTask.UI;

namespace TestTask
{
    public static class Global
    {
        public static UIController UIController => UIController.Instance;
        public static PlayerProgress PlayerProgress => PlayerProgress.Instance;
        public static LevelsList LevelsList => LevelsList.Instance;
        public static LevelManager LevelManager => LevelManager.Default;
        public static PlayerCharacter PlayerCharacter => PlayerCharacter.Current;
        public static GameController GameController => GameController.Instance;
        public static Camera Camera => GameController.Camera;
        public static Level Level => Level.Current;
        public static GeneralParameters GeneralParameters => GeneralParameters.Instance;
        public static WealthParameters WealthParameters => WealthParameters.Instance;
    }
}
