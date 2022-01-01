using System;
using UnityEngine;

namespace Tetris
{
    public class BaseFunction : AbstractFunction
    {
        protected override void Start()
        {
            currentFallingPositions = TetrisManager.instance.GetStartingBaseFunction();
            SetupGo(currentFallingPositions);
            base.Start();
            //AdjustColliderSize();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            print($"<color=#ffdd55>hit this: </color>{other.gameObject.name}");
            TetrisManager.instance.onHitEvent.Invoke();
        }

        protected override void OnFunctionsHitEvent()
        {
            currentFallingPositions = TetrisManager.instance.ResetBaseFunction();
            SetupGo(currentFallingPositions);
        }
    }
}
