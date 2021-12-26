using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuHandler : MonoBehaviour
    {
        private enum SceneNames
        {
            MainMenu,
            FunctionGame
        }
        [SerializeField] private SceneNames sceneToLoad;

        public void OnClickStartGame()
        {
            SceneManager.LoadScene(sceneToLoad.ToString());
        }
    }
}
