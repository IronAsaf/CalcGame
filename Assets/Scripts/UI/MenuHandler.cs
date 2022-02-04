using System;
using Global;
using UnityEngine;

namespace UI
{
    public class MenuHandler : MonoBehaviour
    {
        public void OnEnable()
        {
            
        }

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
