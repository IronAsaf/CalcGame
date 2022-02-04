using Global;
using UnityEngine;

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
