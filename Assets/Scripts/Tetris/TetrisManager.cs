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
        [SerializeField] public Vector3 lineStartingPosition;
        private List<Vector3> startingBaseFunctionPositions;
        public UnityEvent onHitEvent;
        
        private void Awake()
        {
            Singleton();
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
        public List<Vector3> GetNewFallingFunctionListPositions()
        {
            var lstVec2 = level.functionsForLevelList[0].positions;
            var b = lstVec2.Select(PositionsUtility.Vector2ToVector3).ToList();
            //b = PositionsUtility.NormalizePositions(b, COMPACTION);
            return b;
        }

        public List<Vector3> GetBaseFunctionListPositions()
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

        public void ResetBaseFunction()
        {
            //do the MINUS functionality, take the Function of Base and Falling, and do that.
            var newPos = new List<Vector3>();
            baseFunction.SetupGo(newPos);
        }

        public void ResetFallingFunction()
        {
            // Take current SelectFunction's 
            var newPos = new List<Vector3>();
            baseFunction.SetupGo(newPos);
        }

        public void ResetSelectFunction()
        {
            //take from list of the functions available, take the one to the right as if clicked right. Should
            // be circular.
            var newPos = new List<Vector3>();
            baseFunction.SetupGo(newPos);
        }
    }
}
