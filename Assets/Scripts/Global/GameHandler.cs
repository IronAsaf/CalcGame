using System.Collections;
using Data;
using Tetris;
using UI;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Global
{
    public class GameHandler : MonoBehaviour
    {
        [ReadOnly] public PlayerData playerData;
        [SerializeField] private PlayerData playerInfo;
        [SerializeField] private float timeScale = 1f;
        [SerializeField] private int scoreStart = 10000;
        public int currentScore;
        [SerializeField] private float scoreConstraint = 0.05f;
        private void Awake()
        {
            currentScore = scoreStart;
            playerData = Instantiate(playerInfo);
            TimeController();
        }

        private void Start()
        {
            StartCoroutine(GameScore());
            UiManager.Instance.UpdateScore(scoreStart);
            TetrisManager.Instance.onGameEndEvent?.AddListener(EndGame);
        }
        
        private IEnumerator GameScore()
        {
            while (currentScore > 0)
            {
                yield return new WaitForSeconds(scoreConstraint);
                currentScore -= 1;
                if (currentScore <= scoreStart % 10)
                {
                    StartCoroutine(UiManager.Instance.TextUrgency(Color.red));
                }
                UiManager.Instance.UpdateScore(currentScore);
            }
            
            //ENDGAME out of score...
            TetrisManager.Instance.EndGame();
        }
        
        private void TimeController(float newTimer = -1f)
        {
            if (newTimer < 0f)
            {
                Time.timeScale = timeScale;
            }
            else
            {
                Time.timeScale = newTimer;
                timeScale = newTimer;
            }
        }

        private void EndGame()
        {
            StopCoroutine(GameScore());
            UiManager.Instance.FixEndGameScoreText(currentScore);
        }

        public void LoadStartScene()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        public void LoadEndScene()
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
        
    }
}