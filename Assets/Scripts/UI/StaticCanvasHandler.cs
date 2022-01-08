using Tetris;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StaticCanvasHandler : MonoBehaviour
    {
        [SerializeField] private GameObject score;
        [SerializeField] private Image displayedFunction;

        private int currentFunctionIndex = 0;
        private int amountOfFunctionsToCycle;

        private void Start()
        {
            amountOfFunctionsToCycle = TetrisManager.instance.GetLengthOfFunctionsList();
            displayedFunction.sprite = TetrisManager.instance.GetSpriteOfFunctionByIndex(0);
        }

        public void OnClickCycleFunction(int dir)
        {
            var newVal = currentFunctionIndex + dir;
            if (newVal < 0)
            {
                newVal = amountOfFunctionsToCycle - 1;
            }
            else if(newVal >= amountOfFunctionsToCycle)
            {
                newVal = 0;
            }

            currentFunctionIndex = newVal;
            displayedFunction.sprite = TetrisManager.instance.GetSpriteOfFunctionByIndex(currentFunctionIndex);
        }

        public void OnClickActivateFunction()
        {
            TetrisManager.instance.onFunctionChangeEvent.Invoke();
        }
    }
}
