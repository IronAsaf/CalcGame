using UnityEngine;

namespace Tetris
{
    // maybe remove rigid and do update time.time to fall on its own with our own speed.
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingFunction : AbstractFunction
    {
        private new Rigidbody2D rigidbody2D;

        protected override void Awake()
        {
            base.Awake();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            SetupInitialFallingFunction();
            //AdjustColliderSize();
        }
    }
}
