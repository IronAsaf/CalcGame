using System;
using System.Collections;
using TMPro;
using UnityEngine;
/*
 * This script handles the Quit Scene itself, checking to see if you are in WebGL or now
 * to pop the correct thing.
 */
namespace Global
{
    public class QuitSceneHandler : MonoBehaviour
    {
        public GameObject youAreWebGL;
        // Start is called before the first frame update
        private void Awake()
        {
            GameHandler.Instance.playerData.Serialize();
        }

        void Start()
        {
            StartCoroutine(QuitGameDelay());
        }

        private IEnumerator QuitGameDelay()
        {
            yield return new WaitForSeconds(3f);
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                Application.Quit();
            }
            else
            {
                youAreWebGL.SetActive(true);
            }
        }
    }
}
