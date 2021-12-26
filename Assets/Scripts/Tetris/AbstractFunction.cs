using System.Collections.Generic;
using UnityEngine;
using Utility;
using PathCreation;

namespace Tetris
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class AbstractFunction : MonoBehaviour
    {
        [SerializeField] protected Transform[] functionDotsTransRefs;
        protected List<Vector3> currentFallingPositions;
        private GameObject dot;
        private BoxCollider2D refCollider2D;
        private PathCreator pathCreator;

        protected virtual void Awake()
        {
            refCollider2D = GetComponent<BoxCollider2D>();
            pathCreator = GetComponent<PathCreator>();
        }

        protected virtual void AdjustColliderSize()
        {
            refCollider2D.size = PositionsUtility.SizeFromList(currentFallingPositions);
            var center = PositionsUtility.Center(currentFallingPositions);
        }

        protected void SetupDot()
        {
            //dot = new GameObject("pref");
            dot = TetrisManager.instance.dot;
            //dot.GetComponent<SpriteRenderer>().color = Color.red;
        }

        protected void SetupInitialFallingFunction()
        {
            currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            SetupGo(currentFallingPositions);
        }

        protected void SetupGo(List<Vector3> positions)
        {
            if (positions == null) return;
            /*foreach (var positionForGo in currentFallingPositions)
            {
                var goName = "GO: " + positionForGo.x + ", " + positionForGo.y;
                dot.name = goName;
                Instantiate(dot, positionForGo, Quaternion.identity, transform);
            }

            functionDotsTransRefs = GetComponentsInChildren<Transform>();*/
            pathCreator.bezierPath = new BezierPath(positions.ToArray(), false, PathSpace.xy);
            
        }
    }
}
