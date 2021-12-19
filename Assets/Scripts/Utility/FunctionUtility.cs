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
        private static float CalculateImmediateValue(FunctionComponent func)
        {
            return 0;
        }
        //Calculate pairing - i give it 2 values, it does the operation, so if I get 10 and 19, and i am obj type of + i return 29.
        public static float CalculatePairingValue(FunctionComponent left, FunctionComponent right, FunctionComponent oper)
        {
            var val1 = CalculateImmediateValue(left);
            var val2 = CalculateImmediateValue(right);

            var answer = 0f;

            switch (oper.GetCurrentType())
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
