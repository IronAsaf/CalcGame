using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FunctionCreator
{
    [CreateAssetMenu(menuName = "CalcGame/Level Data", fileName = "LevelData_00")]
    public class LevelMaker : SerializedScriptableObject
    {
        [SerializeField] private string levelName;
        [SerializeField] private int difficulty;
        public List<FunctionMaker> functionsForLevelList;
        public FunctionMaker bottomFunction;
    }
}
