using System;
using TMPro;
using UnityEngine;
using Utility;

namespace UI
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject characterCanvas;
        [SerializeField] private GameObject staticsCanvas;
        [SerializeField] private TMP_Text scoreText;

        protected override void Awake()
        {
            base.Awake();
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

        public void UpdateScore(int amount)
        {
            scoreText.text = amount.ToString();
        }
    }
}
