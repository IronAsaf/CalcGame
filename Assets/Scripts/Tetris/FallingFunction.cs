using System;
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
        private float speed = -1f; // TEMP
        protected override void Awake()
        {
            base.Awake();
            startingPos = transform.localPosition;
            rigidbody2DRef = GetComponent<Rigidbody2D>();
        }

        protected override void Start()
        {
            TetrisManager.instance.onFunctionChangeEvent.AddListener(OnFunctionsHitEvent);
            SetupInitialFallingFunction();
            base.Start();
        }

        protected override void OnFunctionsHitEvent()
        {
            transform.SetPositionAndRotation(PositionsUtility.Vector2ToVector3(startingPos),Quaternion.identity);
            currentFallingPositions = TetrisManager.instance.ResetFallingFunction();
            SetupGo(currentFallingPositions);
        }

        private void FixedUpdate()
        {
            rigidbody2DRef.velocity = new Vector2(0, speed);
        }
    }
}
