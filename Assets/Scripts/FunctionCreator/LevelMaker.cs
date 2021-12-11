using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "CalcGame/Level Data", fileName = "LevelData_00")]
    public class LevelMaker : SerializedScriptableObject
    {
        [SerializeField] private string levelName;
        [SerializeField] private int difficulty;
        [SerializeField] private List<FunctionMaker> functionsForLevelList;
    }
}
