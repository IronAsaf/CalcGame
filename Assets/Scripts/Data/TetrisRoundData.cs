using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class TetrisRoundData : IGameRoundData
    {
        public string bottomFunctionName;
        public bool didPlayerWinRound;
        public int playerScore;
        public int startingScore;
        public float timeSpentPlaying;
        public float startTimer, endTimer;
        public TetrisRoundData(string name)
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
