using UnityEngine;
using Utility;

namespace Tetris
{
    public class LineFunction : AbstractFunction
    {
        // Start is called before the first frame update
        [SerializeField] private BaseFunction baseFunction;
        private float endGameY;
        protected override void Start()
        {
            RecenterLine();
            base.Start();
        }

        private void RecenterLine()
        {
            var center = baseFunction.transform.position;
            transform.SetPositionAndRotation(center, Quaternion.identity);
            endGameY = TetrisManager.Instance.GetEndGameYPos();
        }
        protected override void OnFunctionsHitEvent()
        {
            base.OnFunctionsHitEvent();
            var top =PositionsUtility.MostTopVector3(baseFunction.currentFallingPositions);
            if (top.y <= endGameY)
            {
                TetrisManager.Instance.EndGame();
            }
            
        }

        protected override void RestartFunction()
        {
            RecenterLine();
        }
    }
}
