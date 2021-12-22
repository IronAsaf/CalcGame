using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace FunctionCreator
{
    [CreateAssetMenu(menuName = "CalcGame/Function Data", fileName = "FunctionData_00")]
    public class FunctionMaker : SerializedScriptableObject
    {
        [Title("Outward Function Values")]
        [SerializeField] private int amountOfNodes;
        [SerializeField] private Vector4 rectClamp = new(1,2,3,4);
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
        public void CalculatePositions()
        {
            if (!ValidateComponentList(functionComponents))
            {
                Debug.Log($"<color=#ff4466>Encountered an Issue with calculation, see LogErrors</color>");
                return;
            }
            positions = new List<Vector2>();
            var advance = (rectClamp.y - rectClamp.x) / amountOfNodes;
            var isSimpleFunction = functionComponents.Count == 1;
            for (var i = rectClamp.x; i < rectClamp.y; i+=advance)
            {
                var temp = new Vector2(i,0);
                if (isSimpleFunction) // a function that is just like LANX or X^2 and thats it.
                {
                    temp.y += FunctionUtility.CalculateImmediateValue(functionComponents[0], i);

                    positions.Add(temp);
                    continue;
                }
                for (var op = 1; op < functionComponents.Count - 1; op += 2) // Complex function like X + LanX
                {
                    //TODO-0003 - Add arithmetic computability ( Divide comes before Add )

                    switch (functionComponents[op].type)
                    {
                        case FunctionUtility.FunctionalityType.OperatorDivide:
                        case FunctionUtility.FunctionalityType.OperatorMinus:
                        case FunctionUtility.FunctionalityType.OperatorMultiply:
                        case FunctionUtility.FunctionalityType.OperatorPlus:
                            temp.y += FunctionUtility.CalculatePairingValue(functionComponents[op - 1],
                                functionComponents[op + 1], functionComponents[op], i);
                            break;
                        default:
                            Debug.LogWarning("Found unknown operator in calculation");
                            break;
                    }
                }
                positions.Add(temp);
            }
            Debug.Log($"<color=#00cc99>Positions Generated</color>");
        }

        [ButtonGroup("Calculation/Buttons")][Button("ClearAll")]
        public void ClearAll()
        {
            functionComponents = new List<FunctionComponent>();
            positions = new List<Vector2>();
            amountOfNodes = 0;
            rectClamp = Vector4.zero;
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

        private static bool IsOperator(FunctionUtility.FunctionalityType type)
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