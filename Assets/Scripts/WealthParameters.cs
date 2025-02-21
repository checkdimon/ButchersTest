
using UnityEngine;
using TestTask.Gameplay;
using System;

namespace TestTask
{
    [CreateAssetMenu(fileName = nameof(WealthParameters), menuName = Constants.ParametersRoot + nameof(WealthParameters))]
    public class WealthParameters : StaticScriptableObject<WealthParameters>
    {
        [Serializable]
        public class WealthSet
        {
            public EWealthType WealthType;
            public float MinHealthValue;
            public float MaxHealthValue;
        }

        [SerializeField] private WealthSet[] wealthSets;

        public WealthSet[] WealthSets => wealthSets;
    }
}
