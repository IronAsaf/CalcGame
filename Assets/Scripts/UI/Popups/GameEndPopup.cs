using Global;
using Tetris;
using TMPro;
using UnityEngine;

/*
 * This script handles a specific popup for the tetris game, the end game popup.
 */
namespace UI.Popups
{
    public class GameEndPopup : PopupHandler
    {
        [SerializeField] private TMP_Text endGameScreenScoreText;

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
