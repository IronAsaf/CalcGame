namespace Data
{
    public interface IGameRoundData
    {
        public enum GameType
        {
            Tetris
        }

        GameType GetGameType();
    }
}
