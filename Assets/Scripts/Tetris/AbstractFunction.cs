using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using PathCreation;
using PathCreation.Examples;

namespace Tetris
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class AbstractFunction : MonoBehaviour
    {
        protected List<Vector3> currentFallingPositions;
        private BoxCollider2D refCollider2D;
        [SerializeField] private PathCreator pathCreator;
        private RoadMeshCreator roadMeshCreator;

        protected virtual void Awake()
        {
            refCollider2D = GetComponent<BoxCollider2D>();
            pathCreator = GetComponent<PathCreator>();
        }

        protected virtual void AdjustColliderSize()
        {
            refCollider2D.size = PositionsUtility.SizeFromList(currentFallingPositions);
        }

        protected void SetupInitialFallingFunction()
        {
            currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            SetupGo(currentFallingPositions);
        }

        protected void SetupGo(List<Vector3> positions)
        {
            if (positions == null) return;
            try
            {
                pathCreator.bezierPath = new BezierPath(positions, false, PathSpace.xy);
                roadMeshCreator.thickness = 0.02f;
                roadMeshCreator.flattenSurface = true;
                roadMeshCreator.roadWidth = 0.02f;
                roadMeshCreator.TriggerUpdate();
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"<color=#ffdd66>bezier path</color>, There is a issue with the bezier path: {e.Message}");
            }
        }
    }
}
