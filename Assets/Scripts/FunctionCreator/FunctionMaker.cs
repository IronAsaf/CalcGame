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
        public FunctionUtility.FunctionNames functionBaseName; // temp for now.
        public Sprite functionDisplay;

        [Title("Outward Function Values")]
        //public int amountOfNodes;
        public float functionXAdvancement = 0.25f;
        public bool shouldFunctionBeNormalized = true;
        public float functionNormalizeScaler = 1.5f;
        public Vector2 rectClamp = new Vector2(-1.5f,1.5f);
        public Vector2 rectYClamp = new Vector2(-1.5f,1.5f);
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
            positions = FunctionUtility.CalculatePositionsNew(
                functionComponents,
                rectClamp,
                rectYClamp,
                functionXAdvancement,
                shouldFunctionBeNormalized,
                functionNormalizeScaler).ToList();
        }

        [ButtonGroup("Calculation/Buttons")][Button("ClearAll")]
        public void ClearAll()
        {
            functionComponents = new List<FunctionComponent>();
            positions = new List<Vector2>();
            functionXAdvancement = 0.025f;
            shouldFunctionBeNormalized = true;
            rectClamp = new Vector2(-1.5f,1.5f);
            rectYClamp = new Vector2(-1.5f,1.5f);
        }

        //This function will initiate a copy of the needed FunctionMaker Object.
        public void Init(FunctionMaker other)
        {
            functionBaseName = other.functionBaseName;
            functionXAdvancement = other.functionXAdvancement;
            shouldFunctionBeNormalized = other.shouldFunctionBeNormalized;
            functionNormalizeScaler = other.functionNormalizeScaler;
            rectClamp = FunctionUtility.NewMaxClamp(rectClamp, other.rectClamp);
            rectYClamp = FunctionUtility.NewMaxClamp(rectYClamp, other.rectYClamp);
            positions = new List<Vector2>(other.positions);
            functionComponents = new List<FunctionComponent>(other.functionComponents);
        }

        //Flips the function to be -1*F its current position;
        public void FlipFunction()
        {
            // Knowing that the function is already made we just loop through the positions and *-1 them.
            for (int i = 0; i < positions.Count; i++)
            {
                var vec = positions[i] * -1;
                positions[i] = vec;
            }

            for (int i = 0; i < functionComponents.Count; i++)
            {
                if (!FunctionUtility.IsOperator(functionComponents[i].type)) continue;
                functionComponents[i] = functionComponents[i].type switch
                {
                    FunctionUtility.FunctionalityType.OperatorMinus => new FunctionComponent(
                        FunctionUtility.FunctionalityType.OperatorPlus, functionComponents[i].assistiveNumber),
                    FunctionUtility.FunctionalityType.OperatorPlus => new FunctionComponent(
                        FunctionUtility.FunctionalityType.OperatorMinus, functionComponents[i].assistiveNumber),
                    _ => functionComponents[i]
                };
            }
        }
    }
}