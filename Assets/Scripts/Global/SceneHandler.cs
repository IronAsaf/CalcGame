using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Global
{
    public class SceneHandler : Singleton<SceneHandler>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }
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
