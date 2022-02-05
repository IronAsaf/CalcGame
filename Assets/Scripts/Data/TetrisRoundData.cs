namespace Data
{
    [System.Serializable]
    public class TetrisRoundData : IGameRoundData
    {
        public string bottomFunction;
        public bool didPlayerWinRound;
        public int playerScore;
        public int startingScore;
        public float timeSpentPlaying;
        
        public TetrisRoundData()
        {
            
        }

        public TetrisRoundData(TetrisRoundData other)
        {
            
        }
        
        public IGameRoundData.GameType GetGameType()
        {
            return IGameRoundData.GameType.Tetris;
        }
    }
}
