using System;
using UnityEngine;

namespace Tetris
{
    public class BaseFunction : AbstractFunction
    {
        private void Start()
        {
            SetupDot();
            currentFallingPositions = TetrisManager.instance.GetBaseFunctionListPositions();
            SetupGO(currentFallingPositions);
            AdjustColliderSize();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            print($"<color=#ffdd55>hit this: </color>{other.gameObject.name}");
        }
    }
}
