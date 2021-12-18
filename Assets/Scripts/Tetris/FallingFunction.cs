using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace Tetris
{
    // maybe remove rigid and do update time.time to fall on its own with our own speed.
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class FallingFunction : MonoBehaviour
    {
        [SerializeField] [ReadOnly] private Transform[] functionDotsTransRefs;
        private List<Vector3> currentFallingPositions;
        private GameObject dot;
        private new BoxCollider2D collider2D;
        private new Rigidbody2D rigidbody2D;
        private float[] functionEdgesPositions; // top, bot, left, right


        private void Awake()
        {
            collider2D = GetComponent<BoxCollider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            SetupDot();
            SetupInitialFallingFunction();
            AdjustColliderSize();
        }

        private void AdjustColliderSize()
        {
            collider2D.size = PositionsUtility.SizeFromList(currentFallingPositions);
            var center = PositionsUtility.Center(currentFallingPositions);
        }

        private void SetupDot()
        {
            dot = new GameObject("pref");
            var spr = dot.AddComponent<SpriteRenderer>();
            spr.sprite = TetrisManager.instance.spriteForDot;
            spr.color = Color.red;
        }
        private void SetupInitialFallingFunction()
        {
            currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            SetupGO(currentFallingPositions);
        }

        private void SetupGO(List<Vector3> positions)
        {
            if (positions == null) return;
            foreach (var positionForGO in currentFallingPositions)
            {
                var goName = "GO: " + positionForGO.x + ", " + positionForGO.y;
                dot.name = goName;
                Instantiate(dot, positionForGO, Quaternion.identity, transform);
            }

            functionDotsTransRefs = GetComponentsInChildren<Transform>();
        }
    }
}
