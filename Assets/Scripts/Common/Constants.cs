
using UnityEngine;

namespace TestTask
{
    public static class Constants
    {
        public const int ScreenReferenceWidth = 1080;
        public const int ScreenReferenceHeight = 1920;

        public static float ScreenWidthAspect => Screen.width / (float)ScreenReferenceWidth;
        public static float ScreenHeightAspect => Screen.height / (float)ScreenReferenceHeight;

        public const string AssetMenuRoot = "TestTaskRich/";

        public const string ConfigsRoot = AssetMenuRoot + "Configs/";
        public const string ParametersRoot = AssetMenuRoot + "Parameters/";
        public const string LevelsRoot = AssetMenuRoot + "Levels/";
    }
}
