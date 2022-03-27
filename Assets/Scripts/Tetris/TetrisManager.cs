using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using FunctionCreator;
using Global;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Tetris
{
    public class TetrisManager : Singleton<TetrisManager>
    {
        [HideInInspector] public UnityEvent onHitEvent;
        [HideInInspector] public UnityEvent onFunctionChangeEvent;
        [HideInInspector] public UnityEvent onFunctionFlipEvent;
        [HideInInspector] public UnityEvent onFunctionSpeedUpEvent;
        [HideInInspector] public UnityEvent onFunctionSlowDownEvent;
        [HideInInspector] public UnityEvent onGameEndEvent;
        [HideInInspector] public UnityEvent onGamRestart;
        public LevelMaker level;
        [SerializeField] private GameObject endGameScreen;
        [SerializeField] private List<FunctionComponent> currentTopFunction;
        private List<Vector3> startingBaseFunctionPositions;
        private int currentFallingFunctionIndex;
        public FunctionMaker baseFunctionMaker;
        private const float BaseFunctionAdvance = 0.025f;
        private const float EndGameDelay = 1f;
        protected override void Awake()
        {
            base.Awake();
            onHitEvent = new UnityEvent();
            onFunctionChangeEvent = new UnityEvent();
            onGameEndEvent = new UnityEvent();
            onGamRestart = new UnityEvent();
            TetrisManagerAwake();
            onGamRestart.AddListener(RestartTetrisManager);
            
        }


        private void TetrisManagerAwake()
        {
            currentTopFunction = level.functionsForLevelList[0].functionComponents.ToList();
        }
        private void Start()
        {
            InitializeBottomFunction();
        }

        private void InitializeBottomFunction()
        {
            Destroy(baseFunctionMaker);
            baseFunctionMaker = ScriptableObject.CreateInstance<FunctionMaker>();
            baseFunctionMaker.Init(level.bottomFunction);
        }

        private void RestartTetrisManager()
        {
            GeneralUtility.AdjustTimeScale();
            TetrisManagerAwake();
            InitializeBottomFunction();
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
        public float GetNewFallingSpeed(float currentSpeed)
        {
            var diff = GameHandler.Instance.difficulty;
            var clampForSpeed = diff.speedClamp;
            var sped = currentSpeed - diff.speedIncreaseRate;
            //if
            if (sped <= clampForSpeed.y) sped = clampForSpeed.y;
            return sped;
        }
        public Sprite GetSpriteOfFunctionByIndex(int index)
        {
            currentFallingFunctionIndex = index;
            return level.functionsForLevelList[index].functionDisplay;
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
            foreach (var t in currentTopFunction)
            {
                baseFunctionMaker.functionComponents.Add(t);
            }

            baseFunctionMaker.rectClamp = FunctionUtility.NewMaxClamp(baseFunctionMaker.rectClamp,
                level.functionsForLevelList[currentFallingFunctionIndex].rectClamp);
            baseFunctionMaker.rectYClamp = FunctionUtility.NewMaxClamp(baseFunctionMaker.rectYClamp,
                level.functionsForLevelList[currentFallingFunctionIndex].rectYClamp);
            baseFunctionMaker.positions = FunctionUtility.CalculatePositionsNew(baseFunctionMaker.functionComponents, baseFunctionMaker.rectClamp,baseFunctionMaker.rectYClamp, BaseFunctionAdvance, false, 2f);
            var b = baseFunctionMaker.positions.Select(PositionsUtility.Vector2ToVector3).ToList();
            return b;
        }

        public List<Vector3> FlipFallingFunction()
        {
            var func = level.functionsForLevelList[currentFallingFunctionIndex];
            func.FlipFunction();
            var pos = func.positions;
            var b = pos.Select(PositionsUtility.Vector2ToVector3).ToList();
            currentTopFunction = func.functionComponents.ToList();
            return b;
        }
        public List<Vector3> ResetFallingFunction()
        {
            var pos = level.functionsForLevelList[currentFallingFunctionIndex].positions;
            var b = pos.Select(PositionsUtility.Vector2ToVector3).ToList();
            currentTopFunction = level.functionsForLevelList[currentFallingFunctionIndex].functionComponents.ToList();
            return b;
        }

        public void EndGame()
        {
            onGameEndEvent?.Invoke();
            level.ResetLevel();
            StartCoroutine(DelayEndGame());
        }

        private IEnumerator DelayEndGame() // Cut out to the proper place of this.
        {
            yield return new WaitForSeconds(EndGameDelay);
            Time.timeScale = 0f;
            endGameScreen.SetActive(true);
            endGameScreen.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetUpdate(true);
        }
    }
}
