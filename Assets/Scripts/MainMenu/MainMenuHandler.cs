using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuHandler : MonoBehaviour
    {
        public enum SceneNames
        {
            MainMenu,
            FunctionGame,
            QuitScene
        }
        [SerializeField] private SceneNames sceneToLoad;

        public void OnClickStartGame()
        {
            SceneManager.LoadScene(sceneToLoad.ToString());
        }

        public void LoadSceneByName(SceneNames scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}
