using System.Collections;
using Global;
using UnityEngine;
/*
 * This script handles the main menu button inside the tetris game itself.
 * Currently there is no proper menu other than 2 buttons to function.
 */
namespace MainMenu
{
    public class MainMenuHandler : MonoBehaviour
    {
        public void OnClickStartGame(int difficulty)
        {
            print("am i a cunt? probably");
            StartCoroutine(SmallDelay(difficulty));
        }

        private IEnumerator SmallDelay(int difficulty)
        {
            GameHandler.Instance.OnClickDifficultySet(difficulty);
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            print("going to load a thing");
            SceneHandler.Instance.LoadScene(SceneHandler.SceneNames.FunctionGame);
        }

        public void OnClickQuitGame()
        {
            SceneHandler.Instance.LoadScene(SceneHandler.SceneNames.QuitScene);
        }
    }
}
