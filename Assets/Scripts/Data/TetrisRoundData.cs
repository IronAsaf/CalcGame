using UnityEngine;
using Utility;

namespace Data
{
    [System.Serializable]
    public class TetrisRoundData : IGameRoundData
    {
        public FunctionUtility.FunctionNames bottomFunctionName;
        public bool didPlayerWinRound;
        public int playerScore;
        public int startingScore;
        public float timeSpentPlaying;
        public float startTimer, endTimer;

        public TetrisRoundData()
        {
            bottomFunctionName = FunctionUtility.FunctionNames.Abs;
            didPlayerWinRound = false;
            playerScore = 0;
            startingScore = 0;
            timeSpentPlaying = 0f;
            startTimer = 0f;
            endTimer = 0f;
        }
        
        public TetrisRoundData(FunctionUtility.FunctionNames name)
        {
            bottomFunctionName = name;
            startTimer = Time.time;
        }

        public TetrisRoundData(TetrisRoundData other)
        {
            bottomFunctionName = other.bottomFunctionName;
            didPlayerWinRound = other.didPlayerWinRound;
            playerScore = other.playerScore;
            startingScore = other.startingScore;
            startTimer = other.startTimer;
            endTimer = other.endTimer;
        }
        
        public void EndGame(bool hasPlayerWinRound, int endGameScore, int startGameScore)
        {
            endTimer = Time.time;
            timeSpentPlaying = endTimer - startTimer;
            didPlayerWinRound = hasPlayerWinRound;
            playerScore = endGameScore;
            startingScore = startGameScore;
        }
        public IGameRoundData.GameType GetGameType()
        {
            return IGameRoundData.GameType.Tetris;
        }
    }
}
