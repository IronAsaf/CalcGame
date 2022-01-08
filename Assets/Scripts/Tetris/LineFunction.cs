using UnityEngine;
using Utility;

namespace Tetris
{
    public class LineFunction : AbstractFunction
    {
        // Start is called before the first frame update
        [SerializeField] private BaseFunction baseFunction;
        private BoxCollider2D colliderRef;

        protected override void Awake()
        {
            colliderRef = GetComponent<BoxCollider2D>();
        }
        protected override void Start()
        {
            var center = baseFunction.transform.localPosition;
            transform.SetPositionAndRotation(center, Quaternion.identity);
            base.Start();
        }

        protected override void OnFunctionsHitEvent()
        {
            //check if we are below the line.
            var top =PositionsUtility.MostTopVector3(baseFunction.currentFallingPositions);
            if (top.y <= transform.localPosition.y)
            {
                TetrisManager.instance.EndGame();
            }
            
        }
    }
}
