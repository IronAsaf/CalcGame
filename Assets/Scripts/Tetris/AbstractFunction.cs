using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Tetris
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class AbstractFunction : MonoBehaviour
    {
        [SerializeField] protected Transform[] functionDotsTransRefs;
        protected List<Vector3> currentFallingPositions;
        protected GameObject dot;
        protected new BoxCollider2D collider2D;
        protected float[] functionEdgesPositions; // top, bot, left, right
        
        protected virtual void Awake()
        {
            collider2D = GetComponent<BoxCollider2D>();
        }

        protected virtual void AdjustColliderSize()
        {
            collider2D.size = PositionsUtility.SizeFromList(currentFallingPositions);
            var center = PositionsUtility.Center(currentFallingPositions);
        }

        protected void SetupDot()
        {
            dot = new GameObject("pref");
            var spr = dot.AddComponent<SpriteRenderer>();
            spr.sprite = TetrisManager.instance.spriteForDot;
            spr.color = Color.red;
        }

        protected void SetupInitialFallingFunction()
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
