using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FunctionCreator
{
    [CreateAssetMenu(menuName = "CalcGame/Function Data", fileName = "FunctionData_00")]
    public class FunctionMaker : SerializedScriptableObject
    {
        public delegate void SomeDelegate(double num1, double num2);

        public List<SomeDelegate> someDelegates = new List<SomeDelegate>();
        private List<Vector3> positions = new List<Vector3>();
        public string displayString;
        [BoxGroup("Operations", ShowLabel = true)]
        [ButtonGroup("Operations/Buttons")] [Button("+")]
        public void AddOperation(double num1, double num2)
        {
            someDelegates.Add(AddOperation);
        }

        [ButtonGroup("Operations/Buttons")][Button("-")]
        public void MinusOperation(double num1, double num2)
        {
            someDelegates.Add(MinusOperation);
        }
        
        [ButtonGroup("Operations/Buttons")][Button("*")]
        public void MultiplyOperation(double num1, double num2)
        {
            someDelegates.Add(MinusOperation);
        }
        
        [ShowInInspector, PropertySpace]
        [BoxGroup("Functions", ShowLabel = true)]
        [ButtonGroup("Functions/SimpleFunction")][Button("Ln(x)")]
        public void LanFunction(double num1, double num2)
        {
            someDelegates.Add(LanFunction);
        }

        [ShowInInspector, PropertySpace]
        [Button("Preview", ButtonSizes.Large)]
        public void Display()
        {
            
        }

        public List<Vector3> GetPositions()
        {
            return positions;
        }
    }
}
