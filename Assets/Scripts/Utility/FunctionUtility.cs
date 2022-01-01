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

        //Calculate ImmediateValue - for like LogX , i give X it returns value.
        public static float CalculateImmediateValue(FunctionComponent func, float currentXValue)
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
        //Calculate pairing - i give it 2 values, it does the operation, so if I get 10 and 19, and i am obj type of + i return 29.
        public static float CalculatePairingValue(FunctionComponent left, FunctionComponent right, FunctionComponent oper, float currentXValue)
        {
            var val1 = CalculateImmediateValue(left, currentXValue);
            var val2 = CalculateImmediateValue(right, currentXValue);

            var answer = 0f;

            switch (oper.type)
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
        
        public static List<Vector2> CalculatePositions(FunctionMaker function) //TODO-0004 - Make this into a Array not List.
        {
            if (!ValidateComponentList(function.functionComponents))
            {
                Debug.Log($"<color=#ff4466>Encountered an Issue with calculation, see LogErrors</color>");
                return null;
            }
            var positions = new List<Vector2>();
            var advance = (function.rectClamp.y - function.rectClamp.x) / function.amountOfNodes;
            var isSimpleFunction = function.functionComponents.Count == 1;
            for (var i = function.rectClamp.x; i < function.rectClamp.y; i+=advance)
            {
                var temp = new Vector2(i,0);
                if (isSimpleFunction) // a function that is just like LANX or X^2 and thats it.
                {
                    temp.y += CalculateImmediateValue(function.functionComponents[0], i);

                    positions.Add(temp);
                    continue;
                }
                for (var op = 1; op < function.functionComponents.Count - 1; op += 2) // Complex function like X + LanX
                {
                    //TODO-0003 - Add arithmetic computability ( Divide comes before Add )

                    switch (function.functionComponents[op].type)
                    {
                        case FunctionalityType.OperatorDivide:
                        case FunctionalityType.OperatorMinus:
                        case FunctionalityType.OperatorMultiply:
                        case FunctionalityType.OperatorPlus:
                            temp.y += CalculatePairingValue(function.functionComponents[op - 1],
                                function.functionComponents[op + 1], function.functionComponents[op], i);
                            break;
                        default:
                            Debug.LogWarning("Found unknown operator in calculation");
                            break;
                    }
                }
                positions.Add(temp);
            }
            Debug.Log($"<color=#00cc99>Positions Generated</color>");
            return positions;
        }

        private static bool ValidateComponentList(IReadOnlyList<FunctionComponent> components)
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
                case FunctionUtility.FunctionalityType.OperatorDivide:
                case FunctionUtility.FunctionalityType.OperatorMinus:
                case FunctionUtility.FunctionalityType.OperatorMultiply:
                case FunctionUtility.FunctionalityType.OperatorPlus:
                    return true;
            }

            return false;
        }
    }
}
