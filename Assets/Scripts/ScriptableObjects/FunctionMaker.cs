using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "CalcGame/Function Data", fileName = "FunctionData_00")]
    public class FunctionMaker : SerializedScriptableObject
    {
        public delegate void SomeDelegate();

        public List<SomeDelegate> someDelegates = new List<SomeDelegate>();
        
        [BoxGroup("Operations", ShowLabel = true)]
        [ButtonGroup("Operations/Buttons")] [Button("+")]
        public void AddOperation()
        {
            someDelegates.Add(AddOperation);
        }

        [ButtonGroup("Operations/Buttons")][Button("-")]
        public void MinusOperation()
        {
            someDelegates.Add(MinusOperation);
        }
        
        [ButtonGroup("Operations/Buttons")][Button("*")]
        public void MultiplyOperation()
        {
            someDelegates.Add(MinusOperation);
        }
        
        [ShowInInspector, PropertySpace]
        [BoxGroup("Functions", ShowLabel = true)]
        [ButtonGroup("Functions/SimpleFunction")][Button("Ln(x)")]
        public void LanFunction()
        {
            someDelegates.Add(LanFunction);
        }

        [ShowInInspector, PropertySpace]
        [Button("Preview", ButtonSizes.Large)]
        public void Display()
        {
            
        }
    }
}
