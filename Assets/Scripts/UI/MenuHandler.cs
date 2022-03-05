using System;
using Global;
using UnityEngine;

/*
 * This script handles the MainMenu Scene itself with the canvas functionalities here.
 */

namespace UI
{
    public class MenuHandler : MonoBehaviour
    {
        private void Start()
        {
            Awakening();
        }

        private void OnEnable()
        {
            Awakening();
        }

        private void Awakening()
        {
            Time.timeScale = 0f;
        }

        private void Close()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
        public void OnClickCloseMenu()
        {
            Close();
        }

        public void OnClickMainMenu()
        {
            SceneHandler.Instance.LoadScene(SceneHandler.SceneNames.MainMenu);
        }
    }
}
