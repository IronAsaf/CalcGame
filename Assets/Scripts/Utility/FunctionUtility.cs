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

        public static string operatorPlus = "+";
        public static string operatorMinus = "-";
        public static string operatorMultiply = "*";
        public static string operatorDivide = "/";
        public static string logX = "Log[N](x)";
        public static string lanX = "Lan(x)";
        public static string powX = "x^n";
        public static string x = "x";
        public static string abs = "|x|";
        
        //Calculate ImmediateValue - for like LogX , i give X it returns value.
        public static float CalculateImmediateValue()
        {
            return 0;
        }
        //Calculate pairing - i give it 2 values, it does the operation, so if I get 10 and 19, and i am obj type of + i return 29.
        public static float CalculatePairingValue(float num1, float num2)
        {
            return 0;
        }
    }
}
