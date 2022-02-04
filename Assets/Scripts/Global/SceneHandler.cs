using UnityEngine.SceneManagement;
using Utility;

/*
 * This script handles the general scene loading and all that is needed with it.
 * This is one of the DONOTDESTROY scripts.
 */

namespace Global
{
    public class SceneHandler : Singleton<SceneHandler>
    {
        public enum SceneNames
        {
            FunctionGame, MainMenu, QuitScene
        }

        public void LoadScene(SceneNames sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad.ToString(), LoadSceneMode.Single);
        }
    }
}
