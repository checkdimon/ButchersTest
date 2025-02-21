using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    [CreateAssetMenu(fileName = nameof(LevelsList), menuName = Constants.ParametersRoot + nameof(LevelsList))]
    public class LevelsList : StaticScriptableObject<LevelsList>
    {
        public bool randomizedLvls;
        public List<Level> lvls;
    }
}