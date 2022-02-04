using Global;
using UnityEngine;

/*
 * This script handles the MainMenu Scene itself with the canvas functionalities here.
 */

namespace UI
{
    public class MenuHandler : MonoBehaviour
    {
        public void OnClickCloseMenu()
        {
            gameObject.SetActive(false);
        }

        public void OnClickMainMenu()
        {
            SceneHandler.Instance.LoadScene(SceneHandler.SceneNames.MainMenu);
        }
    }
}
