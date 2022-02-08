using System;
using System.Collections.Generic;
using FunctionCreator;
using UnityEngine;

namespace Utility
{
    public static class FunctionUtility
    {
        public enum FunctionalityType
        {
            OperatorPlus,
            OperatorMinus,
            OperatorMultiply,
            OperatorDivide,
            LogX,
            LanX,
            PowX,
            X,
            Abs,
        }

        public enum FunctionNames //Temp for sure.
        {
            LogX,
            LanX,
            XPowerTwo,
            XPowerThree,
            X,
            Abs,
        }

        //Calculate ImmediateValue - for like LogX , i give X it returns value.
        private static float CalculateImmediateValue(FunctionComponent func, float currentXValue)
        {
            var f = 0f;
            switch (func.type)
            {
                case FunctionalityType.LogX:
                    f = (float) Math.Log(currentXValue, func.assistiveNumber);
                    break;
                case FunctionalityType.LanX:
                    f = (float) Math.Log(currentXValue, Math.E);
                    break;
                case FunctionalityType.PowX:
                    f = (float) Math.Pow(currentXValue, func.assistiveNumber);
                    break;
                case FunctionalityType.X:
                    f = currentXValue;
                    break;
                case FunctionalityType.Abs:
                    f = Math.Abs(currentXValue);
                    break;
                default:
                    Debug.LogError("FunctionUtility -- ImmediateCalculation out of Range");
                    break;
            }
            return f;
        }

        private static float CalculateByOperator(float val1, float val2, FunctionalityType func)
        {
            float answer = 0f;
            switch (func)
            {
                case FunctionalityType.OperatorDivide:
                    answer = val1 / val2;
                    break;
                case FunctionalityType.OperatorMinus:
                    answer = val1 - val2;
                    break;
                case FunctionalityType.OperatorMultiply:
                    answer = val1 * val2;
                    break;
                case FunctionalityType.OperatorPlus:
                    answer = val1 + val2;
                    break;
            }

            return answer;
        }
        public static List<Vector2> CalculatePositionsNew(List<FunctionComponent> components, Vector2 rectXClamp, Vector2 rectYClamp, float functionXAdvancement, bool shouldNormalize = true, float normalizeScaler = 1.5f)
        {
            if (!ValidateComponentList(components))
            {
                Debug.Log($"<color=#ff4466>Encountered an Issue with calculation, see LogErrors</color>");
                return null;
            }
            
            var vector2S = new List<Vector2>();
            var isSimpleFunction = components.Count == 1;
            List<FunctionComponent> functions = new List<FunctionComponent>();
            List<FunctionComponent> operators = new List<FunctionComponent>();
            foreach (var func in components)
            {
                if (IsOperator(func.type))
                {
                    operators.Add(func);
                }
                else
                {
                    functions.Add(func);
                }
            }

            for (var x = rectXClamp.x; x <= rectXClamp.y; x+=functionXAdvancement) // generates X's
            {
                var temp = new Vector2(x,0);
                if (isSimpleFunction) // a function that is just like LANX or X^2 and thats it.
                {
                    temp.y  = CalculateImmediateValue(components[0], x);
                    if (float.IsNaN(temp.y )) continue;
                    if (!ValidateVectorConstraint(temp.y, rectYClamp)) continue; // Exceeds clamp.
                    vector2S.Add(temp);
                    continue;
                }
                
                List<float> answers = new List<float>();
                foreach (var func in functions)
                {
                    answers.Add(CalculateImmediateValue(func,x));
                }

                temp.y = CalculateY(answers, operators);
                if (float.IsNaN(temp.y)) continue;
                if (!ValidateVectorConstraint(temp.y, rectYClamp)) continue; // Exceeds clamp.
                vector2S.Add(temp);
            }
            Debug.Log($"<color=#00cc99>Positions Generated</color>");
            if(shouldNormalize)
            {
                vector2S = PositionsUtility.MinMaxScalar(vector2S, normalizeScaler);
                vector2S = PositionsUtility.RecenterAdjustmentValue(vector2S);
            }
            return vector2S;
        }

        private static float CalculateY(List<float> xValues, List<FunctionComponent> operators)
        {
            float val = xValues[0];
            int op = 0;
            for (int i = 1; i < xValues.Count; i++)
            {
                val = CalculateByOperator(val, xValues[i], operators[op].type);
                op++;
            }
            return val;
        }
        
        private static bool ValidateVectorConstraint(float value, Vector2 constraint)
        {
            return value >= constraint.x && value <= constraint.y;
        }

        public static bool ValidateComponentList(IReadOnlyList<FunctionComponent> components)
        {
            if (components.Count == 1 && !IsOperator(components[0].type))
            {
                return true;
            }
            if (components.Count < 3)
            {
                Debug.LogError("Function Data missing enough elements. minimal-format: VAR OP VAR ...");
                return false;
            }
            if (components.Count % 2 != 1)
            {
                Debug.LogError("Function Data needs odd amount of elements, format: VAR OP VAR ...");
                return false;
            }

            for (var i = 1; i < components.Count-1; i+=2)
            {
                if (IsOperator(components[i].type)) continue;
                Debug.LogError("Function Data needs at odd positions a Operator, format: VAR OP VAR ...");
                return false;
            }
            return true;
        }

        private static bool IsOperator(FunctionalityType type)
        {
            switch (type)
            {
                case FunctionalityType.OperatorDivide:
                case FunctionalityType.OperatorMinus:
                case FunctionalityType.OperatorMultiply:
                case FunctionalityType.OperatorPlus:
                    return true;
                default:
                    return false;
            }
        }

        //This will make a bigger clamp for now, that will exceed the top and bottom from both given vectors.
        public static Vector2 NewMaxClamp(Vector2 a, Vector2 b)
        {
            return new Vector2(Math.Min(a.x, b.x), Math.Max(a.y, b.y));
        }
    }
}
