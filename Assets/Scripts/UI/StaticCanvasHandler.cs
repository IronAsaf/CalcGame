using Tetris;
using UnityEngine;
using UnityEngine.UI;
/*
 * This script handles the functionaltiy of the static-like canvas aspects such as the score.
 * And the functions to cycle through as well. As well as the controls of the game. <- -> __
 */
namespace UI
{
    public class StaticCanvasHandler : MonoBehaviour
    {
        [SerializeField] private GameObject score;
        [SerializeField] private Image displayedFunction;
        private bool invokeDownPressEvent;
        private int currentFunctionIndex = 0;
        private int amountOfFunctionsToCycle;

        private void Start()
        {
            amountOfFunctionsToCycle = TetrisManager.Instance.GetLengthOfFunctionsList();
            displayedFunction.sprite = TetrisManager.Instance.GetSpriteOfFunctionByIndex(0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnClickCycleFunction(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnClickCycleFunction(1);
            }
            
            //Add on press here.

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.DownArrow))
            {
                OnSpeedChangeEvent(true);
            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                OnSpeedChangeEvent(false);
            }
        }

        private void OnSpeedChangeEvent(bool speedUp)
        {
            if (speedUp && !invokeDownPressEvent)
            {
                TetrisManager.Instance.onFunctionSpeedUpEvent.Invoke();
                invokeDownPressEvent = true;
            }
            else if (!speedUp)
            {
                invokeDownPressEvent = false;
                TetrisManager.Instance.onFunctionSlowDownEvent.Invoke();
            }
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
            TetrisManager.Instance.onFunctionChangeEvent.Invoke();
        }
    }
}
