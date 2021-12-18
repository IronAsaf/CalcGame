using System.Collections.Generic;
using FunctionCreator;
using UnityEngine;

namespace Tetris
{
    public class TetrisManager : MonoBehaviour
    {
        public static TetrisManager instance;
        public Sprite spriteForDot;
        private LevelMaker level;
        private List<Vector3> startingBaseFunctionPositions;

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
            var lst = new List<Vector3>(); // TODO-0001 - Hook this to the actual level.
            for (var i = 0; i < 50; i++)
            {
                lst.Add(new Vector3(i*0.1f,i*0.1f,0));
            }
            return lst;
        }
    }
}
