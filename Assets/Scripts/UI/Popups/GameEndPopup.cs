using Tetris;
using TMPro;
using UnityEngine;

namespace UI.Popups
{
    public class GameEndPopup : PopupHandler
    {
        [SerializeField] private TMP_Text endGameScreenScoreText;
        private void OnEnable()
        {
            //get the text, set the score, and all that.
            OnEndGame();
        }

        private void OnEndGame()
        {
            //Check if we won
            if (TetrisManager.Instance.level.minimumAmountOfScoreToWin <= UiManager.Instance.currentScore)
            {
                TetrisManager.Instance.level.levelComplete = true;
            }
            else
            {
                TetrisManager.Instance.level.ResetLevel();
            }
        }

        public void OnClickPlayAgain()
        {
            //TODO
        }

        public void OnClickMainMenu()
        {
            //TODO
        }
    }
}
