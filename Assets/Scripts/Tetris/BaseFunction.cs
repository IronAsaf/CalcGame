using UnityEngine;

namespace Tetris
{
    public class BaseFunction : AbstractFunction
    {
        private void Start()
        {
            SetupDot();
            currentFallingPositions = TetrisManager.instance.GetBaseFunctionListPositions();
            AdjustColliderSize();
        }
    }
}
