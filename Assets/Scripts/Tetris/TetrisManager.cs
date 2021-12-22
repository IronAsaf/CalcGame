using System.Collections.Generic;
using System.Linq;
using FunctionCreator;
using UnityEngine;
using Utility;

namespace Tetris
{
    public class TetrisManager : MonoBehaviour
    {
        public static TetrisManager instance;
        public GameObject dot;
        [SerializeField] private LevelMaker level;
        private List<Vector3> startingBaseFunctionPositions;
        private const int COMPACTION = 100;
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
            b = PositionsUtility.CompactPositions(b, COMPACTION);
            return b;
        }

        public List<Vector3> GetBaseFunctionListPositions()
        {
            var lstVec2 = level.bottomFunction.positions;
            var b = lstVec2.Select(PositionsUtility.Vector2ToVector3).ToList();
            b = PositionsUtility.CompactPositions(b, COMPACTION);
            return b;
        }

        // Once they hit it will call for the functions of both bottom and top and will do bot - top so basically take the 
        // value of lan(x) - x or something, calc lanx then calc x, then calc1 - calc2, create new node, add to list, send list to bot
        // force bot to re-render itself, load new function for top, reset top position
        public void OnHitInteraction()
        {
            
        }
    }
}
