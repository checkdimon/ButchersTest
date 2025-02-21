
using UnityEngine;
using Sirenix.OdinInspector;

namespace TestTask
{
    [CreateAssetMenu(fileName = nameof(GeneralParameters), menuName = Constants.ParametersRoot + nameof(GeneralParameters))]
    public class GeneralParameters : StaticScriptableObject<GeneralParameters>
    {
        private const string ValuesTab = "Values";

        [TabGroup(ValuesTab)]
        [SerializeField] private float startHealth;
        [TabGroup(ValuesTab)]
        [SerializeField] private float alcoholHealthValue;
        [TabGroup(ValuesTab)]
        [SerializeField] private float moneyHealthValue;
        [TabGroup(ValuesTab)]
        [SerializeField] private float positiveGateBonusValue;
        [TabGroup(ValuesTab)]
        [SerializeField] private float negativeGateBonusValue;


        public float StartHealth => startHealth;
        public float AlcoholHealthValue => alcoholHealthValue;
        public float MoneyHealthValue => moneyHealthValue;
        public float PositiveGateBonusValue => positiveGateBonusValue;
        public float NegativeGateBonusValue => negativeGateBonusValue;
    }
}
