using UnityEngine;

namespace Tetris
{
    // maybe remove rigid and do update time.time to fall on its own with our own speed.
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class FallingFunction : AbstractFunction
    {
        private new Rigidbody2D rigidbody2D;

        private void Awake()
        {
            collider2D = GetComponent<BoxCollider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
