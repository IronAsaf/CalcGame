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
        public void OnClickStartGame()
        {
            SceneHandler.Instance.LoadScene(SceneHandler.SceneNames.FunctionGame);
        }

        public void OnClickQuitGame()
        {
            SceneHandler.Instance.LoadScene(SceneHandler.SceneNames.QuitScene);
        }
    }
}
