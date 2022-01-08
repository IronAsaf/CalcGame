using System.Collections.Generic;
using System.Linq;
using FunctionCreator;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Tetris
{
    public class TetrisManager : MonoBehaviour
    {
        public static TetrisManager instance;
        [SerializeField] private LevelMaker level;
        [SerializeField] private BaseFunction baseFunction;
        [SerializeField] private FallingFunction fallingFunction;
        [SerializeField] private GameObject endGameScreen;
        private List<Vector3> startingBaseFunctionPositions;
        public UnityEvent onHitEvent;
        public UnityEvent onFunctionChangeEvent;
        private List<FunctionComponent> currentBottomFunction, currentTopFunction;
        private int currentFallingFunctionIndex;
        
        private void Awake()
        {
            Singleton();
            currentBottomFunction = level.bottomFunction.functionComponents.ToList();
            currentTopFunction = level.functionsForLevelList[0].functionComponents.ToList();
        }
        
        private void Singleton()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this);
            }
        }

        /// <summary>
        /// Randomizes the falling function in the beginning, as well as handles the next calling of a function if need be in the middle of the round. 
        /// </summary>
        /// <returns>Returns a list of Vector3's which hold the positions needed to describe a falling function's visual appearance.</returns>
        public List<Vector3> GetStartingFallingFunction()
        {
            currentFallingFunctionIndex = 0;
            var lstVec2 = level.functionsForLevelList[0].positions; //
            var b = lstVec2.Select(PositionsUtility.Vector2ToVector3).ToList();
            return b;
        }

        public int GetLengthOfFunctionsList() => level.functionsForLevelList.Count;

        public Sprite GetSpriteOfFunctionByIndex(int index)
        {
            currentFallingFunctionIndex = index;
            return level.functionsForLevelList[index].functionDisplay;
        }
        public List<Vector3> FetchNewFallingFunction(int currentIndex) // When Select is clicked
        {
            //TODO-0001 - Make all of this cycle in order.
            currentFallingFunctionIndex = currentIndex;
            currentTopFunction = level.functionsForLevelList[currentIndex].functionComponents.ToList();
            var lstVec2 = level.functionsForLevelList[currentIndex].positions; //
            var b = lstVec2.Select(PositionsUtility.Vector2ToVector3).ToList();
            print($"len of the new func's pos is {b.Count}");
            return b;
        }
        
        public List<Vector3> FetchNewFallingFunction() // On Hit
        {
            var lstVec2 = level.functionsForLevelList[currentFallingFunctionIndex].positions; //
            var b = lstVec2.Select(PositionsUtility.Vector2ToVector3).ToList();
            return b;
        }
        
        public List<Vector3> GetStartingBaseFunction()
        {
            var lstVec2 = level.bottomFunction.positions;
            var b = lstVec2.Select(PositionsUtility.Vector2ToVector3).ToList();
            //b = PositionsUtility.NormalizePositions(b, COMPACTION);
            return b;
        }

        private void OnDestroy()
        {
            onHitEvent.RemoveAllListeners();
        }

        private void OnDisable()
        {
            onHitEvent.RemoveAllListeners();
        }

        public List<Vector3> ResetBaseFunction()
        {
            currentBottomFunction.Add(new FunctionComponent(FunctionUtility.FunctionalityType.OperatorMinus));
            foreach (var t in currentTopFunction)
            {
                currentBottomFunction.Add(t);
            }

            var newPos = FunctionUtility.CalculatePositions(currentBottomFunction, level.bottomFunction.rectClamp, 20);
            var b = newPos.Select(PositionsUtility.Vector2ToVector3).ToList();
            return b;
        }

        public List<Vector3> ResetFallingFunction()
        {
            //currentFallingFunctionIndex = selectFunction.GetCurrentIndex();
            var pos = level.functionsForLevelList[currentFallingFunctionIndex].positions;
            var b = pos.Select(PositionsUtility.Vector2ToVector3).ToList();
            return b;
        }

        public void EndGame()
        {
            Time.timeScale = 0f;
            endGameScreen.SetActive(true);
        }
    }
}
