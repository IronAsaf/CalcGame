using System;
using UnityEngine;

namespace Tetris
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BaseFunction : AbstractFunction
    {
        private void Start()
        {
            currentFallingPositions = TetrisManager.instance.GetBaseFunctionListPositions();
            SetupGo(currentFallingPositions);
            AdjustColliderSize();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            print($"<color=#ffdd55>hit this: </color>{other.gameObject.name}");
        }
    }
}
