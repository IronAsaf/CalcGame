namespace Data.Serialize
{
    public class PlayerSerialize
    {
        public string playerName;
        public float score;
        public TetrisSerialize tetrisGameData;

        public PlayerSerialize()
        {
            playerName = "";
            score = 0f;
            tetrisGameData = new TetrisSerialize();
        }
        public PlayerSerialize(string playerName, float score, TetrisSerialize tetrisGameData)
        {
            this.playerName = playerName;
            this.score = score;
            this.tetrisGameData = tetrisGameData;
        }

        public PlayerSerialize(PlayerData data)
        {
            playerName = data.playerName;
            score = data.score;
            tetrisGameData = new TetrisSerialize(data.tetrisGameData);
        }
    }
}
