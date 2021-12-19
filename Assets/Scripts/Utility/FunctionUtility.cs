using System;
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
    }
}
