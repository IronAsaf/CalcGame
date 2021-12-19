using System;
using FunctionCreator;

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
                    break;
                case FunctionalityType.X:
                    break;
                case FunctionalityType.Abs:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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
