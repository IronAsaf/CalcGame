using System.Collections;
using TMPro;
using UnityEngine;

namespace Global
{
    public class QuitSceneHandler : MonoBehaviour
    {
        public GameObject youAreWebGL;
        // Start is called before the first frame update
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
