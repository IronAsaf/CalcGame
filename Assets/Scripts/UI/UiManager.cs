using System;
using UnityEngine;

namespace UI
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance { get; set; }

        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject characterCanvas;
        [SerializeField] private GameObject staticsCanvas;

        private void Awake()
        {
            ToggleCanvases();
        }

        private void ToggleCanvases()
        {
            menuCanvas.SetActive(false);
        }

        public void OnClickMenuButton()
        {
            menuCanvas.SetActive(true);
        }
    }
}
