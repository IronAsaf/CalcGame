using System.Collections.Generic;
using System.Linq;
using FunctionCreator;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Tetris
{
    public class TetrisManager : Singleton<TetrisManager>
    {
        public UnityEvent onHitEvent;
        public UnityEvent onFunctionChangeEvent;
        [SerializeField] private LevelMaker level;
        [SerializeField] private GameObject endGameScreen;
        [SerializeField] private List<FunctionComponent> currentTopFunction;
        private List<Vector3> startingBaseFunctionPositions;
        private int currentFallingFunctionIndex;
        public FunctionMaker baseFunctionMaker;
        private const float BaseFunctionAdvance = 0.01f;
        protected override void Awake()
        {
            base.Awake();
            //currentBottomFunction = level.bottomFunction.functionComponents.ToList();
            currentTopFunction = level.functionsForLevelList[0].functionComponents.ToList();
            onHitEvent = new UnityEvent();
            onFunctionChangeEvent = new UnityEvent();
        }

        private void Start()
        {
            baseFunctionMaker = ScriptableObject.CreateInstance<FunctionMaker>();
            baseFunctionMaker.Init(level.bottomFunction);
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
        public float GetEndGameYPos() => level.lineFunctionYPos;
        public float GetNewFallingSpeed(float currentSpeed) => currentSpeed - level.speedIncreasePerHit;
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
            print($"len of the new function's pos is {b.Count}");
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
            return baseFunctionMaker.positions.Select(PositionsUtility.Vector2ToVector3).ToList();
        }

        protected override void OnDestroy()
        {
            onHitEvent.RemoveAllListeners();
            base.OnDestroy();
        }

        private void OnDisable()
        {
            onHitEvent.RemoveAllListeners();
        }

        public List<Vector3> ResetBaseFunction()
        {
            baseFunctionMaker.functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.OperatorMinus));
            //currentBottomFunction.Add(new FunctionComponent(FunctionUtility.FunctionalityType.OperatorMinus));
            foreach (var t in currentTopFunction)
            {
                baseFunctionMaker.functionComponents.Add(t);
            }
            //check who is the max of the constrains and use that instead. Take the smallest Advancement from them.
            //var v = PositionsUtility.MaxVectorByMag(level.functionsForLevelList[currentFallingFunctionIndex].rectClamp, 
            //need to instantiate a copy of the thing
            //then work from there. Or have a thing so I can keep looking at it.
            //thing = functionMaker thing.
            baseFunctionMaker.rectClamp = FunctionUtility.NewMaxClamp(baseFunctionMaker.rectClamp,
                level.functionsForLevelList[currentFallingFunctionIndex].rectClamp);
            baseFunctionMaker.rectYClamp = FunctionUtility.NewMaxClamp(baseFunctionMaker.rectYClamp,
                level.functionsForLevelList[currentFallingFunctionIndex].rectYClamp);
            baseFunctionMaker.positions = FunctionUtility.CalculatePositions(baseFunctionMaker.functionComponents, baseFunctionMaker.rectClamp,baseFunctionMaker.rectYClamp, BaseFunctionAdvance);
            var b = baseFunctionMaker.positions.Select(PositionsUtility.Vector2ToVector3).ToList();
            return b;
        }

        public List<Vector3> ResetFallingFunction()
        {
            //currentFallingFunctionIndex = selectFunction.GetCurrentIndex();
            var pos = level.functionsForLevelList[currentFallingFunctionIndex].positions;
            var b = pos.Select(PositionsUtility.Vector2ToVector3).ToList();
            currentTopFunction = level.functionsForLevelList[currentFallingFunctionIndex].functionComponents.ToList();
            return b;
        }

        public void EndGame()
        {
            Time.timeScale = 0f;
            endGameScreen.SetActive(true);
        }
    }
}
