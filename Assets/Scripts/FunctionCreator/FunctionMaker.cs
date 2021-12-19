using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace FunctionCreator
{
    [CreateAssetMenu(menuName = "CalcGame/Function Data", fileName = "FunctionData_00")]
    public class FunctionMaker : SerializedScriptableObject
    {
        [BoxGroup("Operations", ShowLabel = true)]
        [ButtonGroup("Operations/Buttons")] [Button("+")]
        public void AddOperation()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.operatorPlus,FunctionUtility.FunctionalityType.OperatorPlus));
        }

        [ButtonGroup("Operations/Buttons")][Button("-")]
        public void MinusOperation()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.operatorMinus,FunctionUtility.FunctionalityType.OperatorMinus));
        }
        
        [ButtonGroup("Operations/Buttons")][Button("*")]
        public void MultiplyOperation()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.operatorMultiply,FunctionUtility.FunctionalityType.OperatorMultiply));
        }
        
        [ShowInInspector, PropertySpace]
        [BoxGroup("Functions", ShowLabel = true)]
        [ButtonGroup("Functions/Buttons_1")][Button("x")]
        public void VariableX()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.x,FunctionUtility.FunctionalityType.X));
        }
        [ButtonGroup("Functions/Buttons_2")][Button("x^n")]
        public void PowerX(float power)
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.powX,FunctionUtility.FunctionalityType.PowX,power));
        }
        [ButtonGroup("Functions/Buttons_3")][Button("Log[N](x)")]
        public void LogFunction(float baseValue)
        {
            if (baseValue <= 0) baseValue = 1;
            functionComponents.Add(new FunctionComponent(FunctionUtility.logX,FunctionUtility.FunctionalityType.LogX,baseValue));
        }
        [ButtonGroup("Functions/Buttons_4")][Button("|x|")]
        public void AbsFunction()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.abs,FunctionUtility.FunctionalityType.Abs));
        }
        [ButtonGroup("Functions/Buttons_5")][Button("Ln(x)")]
        public void LanFunction()
        {
            functionComponents.Add(new FunctionComponent(FunctionUtility.lanX,FunctionUtility.FunctionalityType.LanX));
        }
        
        public List<FunctionComponent> functionComponents;
    }
}
