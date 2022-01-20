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
            var center = baseFunction.transform.position;
            transform.SetPositionAndRotation(center, Quaternion.identity);
            endGameY = TetrisManager.Instance.GetEndGameYPos();
            base.Start();
        }

        protected override void OnFunctionsHitEvent()
        {
            base.OnFunctionsHitEvent();
            var top =PositionsUtility.MostTopVector3(baseFunction.currentFallingPositions);
            if (top.y <= endGameY)
            {
                //TetrisManager.Instance.EndGame();
            }
            
        }
    }
}
