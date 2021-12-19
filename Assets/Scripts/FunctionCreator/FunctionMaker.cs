using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FunctionCreator
{
    [CreateAssetMenu(menuName = "CalcGame/Function Data", fileName = "FunctionData_00")]
    public class FunctionMaker : SerializedScriptableObject
    {
        /*
         * char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

string text = "one\ttwo three:four,five six seven";
System.Console.WriteLine($"Original text: '{text}'");

string[] words = text.Split(delimiterChars);
         */
        public List<string> functionComponents;
        public string displayString;
        [BoxGroup("Operations", ShowLabel = true)]
        [ButtonGroup("Operations/Buttons")] [Button("+")]
        public void AddOperation(double num1, double num2)
        {
            functionComponents.Add("+");
        }

        [ButtonGroup("Operations/Buttons")][Button("-")]
        public void MinusOperation(double num1, double num2)
        {
            functionComponents.Add("-");
        }
        
        [ButtonGroup("Operations/Buttons")][Button("*")]
        public void MultiplyOperation()
        {
            functionComponents.Add("*");
        }
        
        [ShowInInspector, PropertySpace]
        [BoxGroup("Functions", ShowLabel = true)]
        [ButtonGroup("Functions/SimpleVariables")][Button("x")]
        public void VariableX()
        {
            functionComponents.Add("x");
        }
        [ButtonGroup("Functions/SimpleVariables")][Button("x^n")]
        public void PowerX(float power)
        {
            functionComponents.Add("x^"+power);
        }
        [ButtonGroup("Functions/SimpleVariables")][Button("Log[N](x)")]
        public void LogFunction(float baseValue)
        {
            if (baseValue <= 0) baseValue = 1;
            functionComponents.Add("Log["+baseValue+"](x)");
        }
        [ButtonGroup("Functions/SimpleVariables")][Button("|x|")]
        public void AbsFunction()
        {
            functionComponents.Add("|x|");
        }
        [ButtonGroup("Functions/SimpleVariables")][Button("Ln(x)")]
        public void LanFunction()
        {
            functionComponents.Add("ln(x)");
        }

        [ShowInInspector, PropertySpace]
        [Button("Preview", ButtonSizes.Large)]
        public void Display()
        {
            
        }
    }
}
