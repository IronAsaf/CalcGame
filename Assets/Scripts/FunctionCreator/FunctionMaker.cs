using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace FunctionCreator
{
    [CreateAssetMenu(menuName = "CalcGame/Function Data", fileName = "FunctionData_00")]
    public class FunctionMaker : SerializedScriptableObject
    {
        [Title("Outward Function Values")]
        public int amountOfNodes;
        public Vector2 rectClamp;
        public List<Vector2> positions;
        [Title("Function Creation")]
        public List<FunctionComponent> functionComponents;
        
        [BoxGroup("Operations", ShowLabel = true)]
        [ButtonGroup("Operations/Buttons")] [Button("+")]
        public void AddOperation()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.OperatorPlus));
        }

        [ButtonGroup("Operations/Buttons")][Button("-")]
        public void MinusOperation()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.OperatorMinus));
        }
        
        [ButtonGroup("Operations/Buttons")][Button("*")]
        public void MultiplyOperation()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.OperatorMultiply));
        }
        
        [ButtonGroup("Operations/Buttons")][Button("/")]
        public void DivideOperation()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.OperatorDivide));
        }
        
        [BoxGroup("Functions", ShowLabel = true)]
        [ButtonGroup("Functions/Buttons_1")][Button("x")]
        public void VariableX()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.X));
        }
        [ButtonGroup("Functions/Buttons_2")][Button("x^n")]
        public void PowerX(float power)
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.PowX,power));
        }
        [ButtonGroup("Functions/Buttons_3")][Button("Log[N](x)")]
        public void LogFunction(float baseValue)
        {
            if (baseValue <= 0) baseValue = 1;
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.LogX,baseValue));
        }
        [ButtonGroup("Functions/Buttons_4")][Button("|x|")]
        public void AbsFunction()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.Abs));
        }
        [ButtonGroup("Functions/Buttons_5")][Button("Ln(x)")]
        public void LanFunction()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.FunctionalityType.LanX));
        }

        [BoxGroup("Calculation", ShowLabel = true)]
        [ButtonGroup("Calculation/Buttons")][Button("CalculatePositions")]
        public void CalculatePositions() //TODO-0004 - Make this into a Array not List.
        {
            positions = FunctionUtility.CalculatePositions(this).ToList();
        }

        [ButtonGroup("Calculation/Buttons")][Button("ClearAll")]
        public void ClearAll()
        {
            functionComponents = new List<FunctionComponent>();
            positions = new List<Vector2>();
            amountOfNodes = 0;
            rectClamp = Vector4.zero;
        }
    }
}