using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Tetris
{
    // maybe remove rigid and do update time.time to fall on its own with our own speed.
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingFunction : AbstractFunction
    {
        private Rigidbody2D rigidbody2DRef;
        private Vector2 startingPos;
        protected override void Awake()
        {
            base.Awake();
            startingPos = transform.localPosition;
            rigidbody2DRef = GetComponent<Rigidbody2D>();
            TetrisManager.instance.onFunctionChangeEvent.AddListener(OnFunctionsHitEvent);
        }

        protected override void Start()
        {
            SetupInitialFallingFunction();
            base.Start();
        }

        protected override void OnFunctionsHitEvent()
        {
            transform.SetPositionAndRotation(PositionsUtility.Vector2ToVector3(startingPos),Quaternion.identity);
            currentFallingPositions = TetrisManager.instance.ResetFallingFunction();
            SetupGo(currentFallingPositions);
        }
    }
}
