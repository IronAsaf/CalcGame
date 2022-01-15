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
            print($"register to on hit event - {gameObject.name}");
            TetrisManager.Instance.onHitEvent.AddListener(OnFunctionsHitEvent);
        }

        protected void SetupInitialFallingFunction()
        {
            currentFallingPositions = TetrisManager.Instance.GetStartingFallingFunction();
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
                    $"<color=#ffdd66>[{gameObject.name}] bezier path</color> [{positions.Count}] There is a issue with the bezier path: {e.Message}");
            }
        }

        protected virtual void OnDisable()
        {
            TetrisManager.Instance.onHitEvent.RemoveListener(OnFunctionsHitEvent);
        }

        protected void OnDestroy()
        {
            TetrisManager.Instance.onHitEvent.RemoveListener(OnFunctionsHitEvent);
        }

        protected virtual void OnFunctionsHitEvent()
        {
            print($"event handle on hit of {gameObject.name}");
        }
    }
}
