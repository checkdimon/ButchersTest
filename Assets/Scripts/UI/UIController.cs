
using System;
using UnityEngine;

namespace TestTask.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private RectTransform screensContainer;
        [SerializeField] private RectTransform progressBarContainer;

        public RectTransform ProgressBarContainer => progressBarContainer;

        public static UIController Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public T ShowScreen<T>(ScreenParameters parameters = null) where T : ScreenBase
        {
            var currentScreen = GetScreen<T>();
            if (currentScreen != null)
            {
                return currentScreen;
            }

            var screenPrefab = Resources.Load<T>("Screens/" + typeof(T).Name);
            var screen = Instantiate(screenPrefab, screensContainer);
            screen.Show(parameters);
            return screen;
        }

        public void HideScreen<T>(Action onHiddenCallback = null) where T : ScreenBase
        {
            var screen = GetScreen<T>();
            if (screen == null)
            {
                return;
            }

            screen.Hide();
        }

        public T GetScreen<T>() where T : ScreenBase
        {
            return screensContainer.GetComponentInChildren<T>(true);
        }
    }
}
