using System.Collections;
using UI;
using UnityEngine;
/*
 * This class handles the non-functional aspects of the tetris game, like the score and anything else.
 * it also collects the data of the game, sends it to the player data.
 * 
 */
namespace Tetris
{
    public class TetrisGameHandler : MonoBehaviour
    {
        [SerializeField] private float timeScale = 1f;
        [SerializeField] private int scoreStart = 10000;
        public int currentScore;
        [SerializeField] private float scoreConstraint = 0.05f;
        // Start is called before the first frame update
        void Awake()
        {
            currentScore = scoreStart;
        }
        private void Start()
        {
            StartCoroutine(GameScore());
            UiManager.Instance.UpdateScore(scoreStart);
            TetrisManager.Instance.onGameEndEvent?.AddListener(EndGame);
            TetrisManager.Instance.onGamRestart?.AddListener(OnGameRestart);
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
            
            //todo update player data here.
        }

        private void OnGameRestart()
        {
            currentScore = scoreStart;
            TimeController(1f);
            StartCoroutine(GameScore());
        }
    }
}
