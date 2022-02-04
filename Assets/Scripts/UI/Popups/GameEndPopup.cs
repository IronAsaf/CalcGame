using Global;
using Tetris;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                
            }
        }

        public void OnClickPlayAgain()
        {
            TetrisManager.Instance.level.ResetLevel();
            TetrisManager.Instance.onGamRestart.Invoke();
            gameObject.SetActive(false);
        }

        public void OnClickMainMenu()
        {
            SceneHandler.Instance.LoadScene(SceneHandler.SceneNames.MainMenu);
        }
    }
}
