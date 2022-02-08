using System;
using System.Collections;
using Data;
using Global;
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
        [SerializeField] private TetrisRoundData currentRound;
        [SerializeField] private TetrisFunctionData currentFunctionData;
        private TetrisData tetrisData;
        void Awake()
        {
            tetrisData = GameHandler.Instance.playerData.tetrisGameData;
            currentScore = scoreStart;
            
        }

        private void GatherRoundData()
        {
            var bottomFunctionName = TetrisManager.Instance.baseFunctionMaker.functionBaseName;
            currentFunctionData = tetrisData.GetCurrentFunctionData(bottomFunctionName);
            currentRound = new TetrisRoundData(bottomFunctionName);
        }
        private void Start()
        {
            GatherRoundData();
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
            currentRound.EndGame(TetrisManager.Instance.level.levelComplete,currentScore,scoreStart);
            GameHandler.Instance.playerData.tetrisGameData.AddRound(currentRound);
            //todo update player data here.
        }

        private void OnGameRestart()
        {
            currentScore = scoreStart;
            TimeController(1f);
            StartCoroutine(GameScore());
            GatherRoundData();
        }
    }
}
