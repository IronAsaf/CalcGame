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
        [SerializeField] private Vector2 clampOfX;
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
            var advance = (clampOfX.y - clampOfX.x) / amountOfNodes;
            
            for (var i = clampOfX.x; i < clampOfX.y; i+=advance)
            {
                var temp = new Vector2(i,0);
                for (var op = 1; op < functionComponents.Count - 1; op += 2)
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

        private static bool ValidateComponentList(IReadOnlyList<FunctionComponent> components)
        {
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
                switch (components[i].type)
                {
                    case FunctionUtility.FunctionalityType.OperatorDivide:
                    case FunctionUtility.FunctionalityType.OperatorMinus:
                    case FunctionUtility.FunctionalityType.OperatorMultiply:
                    case FunctionUtility.FunctionalityType.OperatorPlus:
                        continue;
                    default:
                        Debug.LogError("Function Data needs an operator between each variable, format: VAR OP VAR ...");
                        return false;
                }
            }
            return true;
        }
    }
}