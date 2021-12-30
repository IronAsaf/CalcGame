using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using PathCreation;
using PathCreation.Examples;

namespace Tetris
{
    
    public abstract class AbstractFunction : MonoBehaviour
    {
        protected List<Vector3> currentFallingPositions;
        private MeshCollider refCollider2D;
        [SerializeField] private PathCreator pathCreator;
        private RoadMeshCreator roadMeshCreator;

        protected virtual void Awake()
        {
            refCollider2D = GetComponentInChildren<MeshCollider>();
            pathCreator = GetComponent<PathCreator>();
            roadMeshCreator = GetComponentInChildren<RoadMeshCreator>();
        }

        protected virtual void AdjustColliderSize()
        {
            //refCollider2D.size = PositionsUtility.SizeFromList(currentFallingPositions);
            StartCoroutine(ColliderWait());
        }

        private IEnumerator ColliderWait()
        {
            refCollider2D.convex = false;
            yield return new WaitForEndOfFrame();
            refCollider2D.convex = true;
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
