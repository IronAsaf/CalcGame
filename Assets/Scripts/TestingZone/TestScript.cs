using System;
using System.Collections.Generic;
using FunctionCreator;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;
using Utility;

namespace TestingZone
{
    public class TestScript : MonoBehaviour
    {
        public FunctionMaker scriptable;
        public bool useScriptable = true;
        
        public Vector2 clamp = new(-1000, 1000); 
        public float step = 10f;
        public bool shouldNorma = true;
        public float normaScale = 3f;
        public List<FunctionComponent> comps;
        public List<Vector2> positions;
        
        public PathCreator pathCreator;
        public RoadMeshCreator roadMeshCreator;
        public void OnClick()
        {
            if (useScriptable)
            {
                RenderStuff(scriptable.positions);
            }
            else
            {
                CalcPos();
                SetupGo();
            }
            
        }

        private void CalcPos()
        {
            positions = FunctionUtility.CalculatePositionsNew(comps, clamp,clamp,step,shouldNorma,normaScale);
        }
        private void SetupGo()
        {
            if (positions == null) return;
            try
            {
                RenderStuff(positions);
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"<color=#ffdd66>[{gameObject.name}] bezier path</color> [{positions.Count}] There is a issue with the bezier path: {e.Message}");
            }
        }

        private void RenderStuff(List<Vector2> pos)
        {
            List<Vector3> pos3 = new List<Vector3>();
            foreach (var po in pos)
            {
                pos3.Add(PositionsUtility.Vector2ToVector3(po));
            }
            
            
            pathCreator.bezierPath = new BezierPath(pos3, false, PathSpace.xy);
            roadMeshCreator.thickness = 0.02f;
            roadMeshCreator.flattenSurface = true;
            roadMeshCreator.roadWidth = 0.02f;
            roadMeshCreator.TriggerUpdate();
        }
    }
}
