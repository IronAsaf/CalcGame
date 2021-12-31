using System;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

namespace Tetris
{
    public abstract class AbstractFunction : MonoBehaviour
    {
        public List<Vector3> currentFallingPositions;
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private RoadMeshCreator roadMeshCreator;

        protected virtual void Awake()
        {
            pathCreator = GetComponent<PathCreator>();
            roadMeshCreator = GetComponentInChildren<RoadMeshCreator>();
        }

        protected virtual void Start()
        {
            TetrisManager.instance.onHitEvent.AddListener(OnFunctionsHitEvent);
        }

        protected void SetupInitialFallingFunction()
        {
            currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();
            SetupGo(currentFallingPositions);
        }

        public void SetupGo(List<Vector3> positions)
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

        protected virtual void OnDisable()
        {
            TetrisManager.instance.onHitEvent.RemoveListener(OnFunctionsHitEvent);
        }

        protected void OnDestroy()
        {
            TetrisManager.instance.onHitEvent.RemoveListener(OnFunctionsHitEvent);
        }

        protected virtual void OnFunctionsHitEvent()
        {
            
        }
    }
}
