namespace Tetris
{
    public class SelectFunction : AbstractFunction
    {
        private int lengthOfTotalFunctions;
        private int currentIndex;
        protected override void Start()
        {
            currentFallingPositions = TetrisManager.instance.GetStartingFallingFunction();
            SetupGo(currentFallingPositions);
            //base.Start();
            lengthOfTotalFunctions = TetrisManager.instance.GetLengthOfFunctionsList();
        }

        public void OnClickSelectFunction(int dir)
        {
            currentIndex += dir;
            if (currentIndex >= lengthOfTotalFunctions) // exceed right, loop start
                currentIndex = 0;
            else if (currentIndex < 0) // exceed left, loop end
                currentIndex = lengthOfTotalFunctions - 1;
            //print($"len: {lengthOfTotalFunctions}, current index: {currentIndex}");
            currentFallingPositions = TetrisManager.instance.FetchNewFallingFunction(currentIndex);
            SetupGo(currentFallingPositions);
        }

        public int GetCurrentIndex() => currentIndex;
        public void OnClickActivate()
        {
            TetrisManager.instance.ResetSelectFunction();
        }

        protected override void OnFunctionsHitEvent()
        {
            OnClickActivate();
        }
    }
}
