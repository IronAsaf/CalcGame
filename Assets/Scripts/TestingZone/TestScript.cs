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
        
        public List<Vector2> CalculatePositions(List<FunctionComponent> components, Vector2 rectXClamp, Vector2 rectYClamp, float functionXAdvancement, bool shouldNormalize = true, float normalizeScaler = 1.5f)
        {
            if (!FunctionUtility.ValidateComponentList(components))
            {
                Debug.Log($"<color=#ff4466>Encountered an Issue with calculation, see LogErrors</color>");
                return null;
            }
            
            var vector2S = new List<Vector2>();
            var isSimpleFunction = components.Count == 1;
            Debug.Log("Calculating the Function: " + rectXClamp + " y: " + rectYClamp + " adv:" + functionXAdvancement + " I will have: " + Math.Abs(rectXClamp.x-rectXClamp.y)/functionXAdvancement + " dots.");
            for (var i = rectXClamp.x; i <= rectXClamp.y; i+=functionXAdvancement)
            {
                var temp = new Vector2(i,0);
                if (isSimpleFunction) // a function that is just like LANX or X^2 and thats it.
                {
                    temp.y += FunctionUtility.CalculateImmediateValue(components[0], i);
                    //if (!ValidateVectorConstraint(temp.y, rectYClamp)) continue; // Exceeds clamp.
                    vector2S.Add(temp);
                    continue;
                }
                for (var op = 1; op < components.Count - 1; op += 2) // Complex function like X + LanX
                {
                    //TODO-0003 - Add arithmetic computability ( Divide comes before Add )

                    switch (components[op].type)
                    {
                        case FunctionUtility.FunctionalityType.OperatorDivide:
                        case FunctionUtility.FunctionalityType.OperatorMinus:
                        case FunctionUtility.FunctionalityType.OperatorMultiply:
                        case FunctionUtility.FunctionalityType.OperatorPlus:
                            temp.y += FunctionUtility.CalculatePairingValue(components[op - 1],
                                components[op + 1], components[op], i);
                            break;
                        default:
                            Debug.LogWarning("Found unknown operator in calculation");
                            break;
                    }
                }
                //if (!ValidateVectorConstraint(temp.y, rectYClamp)) continue; // Exceeds clamp.
                vector2S.Add(temp);
            }
            Debug.Log($"<color=#00cc99>Positions Generated</color>");
            //calc it by VAL-MIN/MAX-MIN 
            //MAX = most top right
            //MIN = MOST bottom LEFT
            // Do for X do for Y. 
            //idk if this will work but we should try it. 
            if(shouldNormalize)
            {
                vector2S = PositionsUtility.MinMaxScalar(vector2S, normalizeScaler);
            }
            return vector2S;
        }
    }
}
