
using System;
using UnityEngine;

namespace TestTask.UI
{
    public class LobbyScreen : ScreenBase
    {
        public class Parameters : ScreenParameters
        {
            public Action GameStarted;
        }

        [SerializeField] private PointerDownEventInterceptor tutorialButton;

        private Parameters parameters;

        public override void Show(ScreenParameters parameters)
        {
            base.Show(parameters);
            this.parameters = parameters as Parameters;

            tutorialButton.OnDown += OnTutorialButtonDown;
        }

        public void SetStateTutorial(bool state)
        {
            tutorialButton.gameObject.SetActive(state);
        }

        private void OnTutorialButtonDown()
        {
            SetStateTutorial(false);
            parameters.GameStarted?.Invoke();
            Hide();
        }
    }
}
