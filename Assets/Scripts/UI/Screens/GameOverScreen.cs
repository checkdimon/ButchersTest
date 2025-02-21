
using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UI
{
    public class GameOverScreen : ScreenBase
    {
        public class Parameters : ScreenParameters
        {
        }

        private Parameters parameters;

        private void Awake()
        {
        }

        public override void Show(ScreenParameters parameters)
        {
            base.Show(parameters);

            this.parameters = parameters as Parameters;
        }
    }
}
