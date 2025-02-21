
using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UI
{
    public class GameplayScreen : ScreenBase
    {
        public class Parameters : ScreenParameters
        {
            public Action Exit;
        }

        [SerializeField] private Button exitButton;

        private Parameters parameters;

        private void Awake()
        {
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        public override void Show(ScreenParameters parameters)
        {
            base.Show(parameters);

            this.parameters = parameters as Parameters;
        }

        private void OnExitButtonClicked()
        {
            parameters.Exit?.Invoke();
            Hide();
        }
    }
}
