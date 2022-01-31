using System;
using System.Collections;
using DG.Tweening;
using Tetris;
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
        [SerializeField] private TMP_Text endGameScreenScoreText;
        public int currentScore;
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
            currentScore = amount;
        }

        public IEnumerator TextUrgency(Color color, float length = 1f)
        {
            yield return new DOTweenCYInstruction.WaitForCompletion(scoreText.DOColor(color, length));
        }

        public void FixEndGameScoreText(int amount)
        {
            endGameScreenScoreText.text = amount.ToString();
            currentScore = amount;
        }
    }
}
