using System.Collections;
using Global;
using Tetris;
using TMPro;
using UnityEngine;

namespace UI.Popups
{
    public class RestartGamePopUp : PopupHandler
    {
        public TMP_Text displayText;
        [SerializeField] private float displayTimer = 3f;
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public override void OnPopupDisplay()
        {
            gameObject.SetActive(true);
            displayText.text = "Restarting game in " + displayTimer + " seconds";
            StartCoroutine(PopupDelay());
        }

        private IEnumerator PopupDelay()
        {
            yield return new WaitForSeconds(displayTimer);
            TetrisManager.Instance.onGamRestart.Invoke();
            gameObject.SetActive(false);
        }
    }
}
