using System;

namespace Tetris
{
    public class SelectFunction : AbstractFunction
    {
        private void Start()
        {
            currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            SetupGo(currentFallingPositions);
        }

        public void OnClickSelectFunction(int dir)
        {
            if (dir < 0)
            {
                //go left
                currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            }
            else // go right
            {
                currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            }
            SetupGo(currentFallingPositions);
        }
    }
}
