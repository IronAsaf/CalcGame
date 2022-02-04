using Tetris;
using UnityEngine;
using UnityEngine.UI;
/*
 * This script handles the functionaltiy of the static-like canvas aspects such as the score.
 * And the functions to cycle through as well.
 */
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
            amountOfFunctionsToCycle = TetrisManager.Instance.GetLengthOfFunctionsList();
            displayedFunction.sprite = TetrisManager.Instance.GetSpriteOfFunctionByIndex(0);
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
            displayedFunction.sprite = TetrisManager.Instance.GetSpriteOfFunctionByIndex(currentFunctionIndex);
        }

        public void OnClickActivateFunction()
        {
            TetrisManager.Instance.onFunctionChangeEvent.Invoke();
        }
    }
}
