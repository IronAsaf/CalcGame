namespace Tetris
{
    public class SelectFunction : AbstractFunction
    {
        protected override void Start()
        {
            currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            SetupGo(currentFallingPositions);
            base.Start();
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

        public void OnClickActivate()
        {
            TetrisManager.instance.ResetFallingFunction();
            TetrisManager.instance.ResetSelectFunction();
        }

        protected override void OnFunctionsHitEvent()
        {
            OnClickActivate();
        }
    }
}
