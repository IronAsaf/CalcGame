using System.Collections.Generic;
using FunctionCreator;
using UnityEngine;

/*
 * do this with game objects and add sprite circle, constant size, and just do i t per tha mount of vector pos you get and put iit under the transforms.
 * 
 */

namespace Tetris
{
    public class TetrisManager : MonoBehaviour
    {
        public static TetrisManager instance;
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

        private void FetchFunctions()
        {
            
        }

        /// <summary>
        /// Randomizes the falling function in the beginning, as well as handles the next calling of a function if need be in the middle of the round. 
        /// </summary>
        /// <returns>Returns a list of Vector3's which hold the positions needed to describe a falling function's visual appearance.</returns>
        public List<Vector3> GetNewFallingFunctionListPositions()
        {
            return null;
        }
        
    }
}
