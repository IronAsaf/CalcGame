namespace Data
{
    /*
     * An interface for the type of Game Data.
     */
    public interface IGameRoundData
    {
        public enum GameType
        {
            Tetris
        }

        GameType GetGameType();
    }
}
