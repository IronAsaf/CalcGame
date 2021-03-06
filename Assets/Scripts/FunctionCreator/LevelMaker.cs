using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FunctionCreator
{
    [CreateAssetMenu(menuName = "CalcGame/Level Data", fileName = "LevelData_00")]
    public class LevelMaker : SerializedScriptableObject
    {
        [SerializeField] public string levelName;
        [SerializeField] public int difficulty;
        [SerializeField] public List<FunctionMaker> functionsForLevelList;
        [SerializeField] public FunctionMaker bottomFunction;
        [SerializeField] public float lineFunctionYPos = 0;
        [SerializeField] public bool levelComplete = false;
        private void Awake()
        {
            ReorderList();
        }

        private void ReorderList()
        {
            foreach (var func in functionsForLevelList)
            {
                if (func.name.Equals(bottomFunction.name))
                {
                    var baser=func;
                    functionsForLevelList.Remove(func);
                    functionsForLevelList.Insert(functionsForLevelList.Count/2,baser);
                    break;
                }
            }
            
        }

        public void ResetLevel()
        {
            //generate a new bottom function
            var rand = Random.Range(0, functionsForLevelList.Count);
            bottomFunction = functionsForLevelList[rand];

            foreach (var func in functionsForLevelList)
            {
                func.ResetFunctionDefaults();
            }
            ReorderList();
        }
    }
}
