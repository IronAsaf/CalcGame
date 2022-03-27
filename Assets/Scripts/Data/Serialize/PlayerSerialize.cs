namespace Data.Serialize
{
    /*
     * Class to save the data in a JSON way. This is because the ScriptableObject doesn't serialize good in JSON.
     This saves the PlayerData, in the future will save passwords and all that as well.
     */
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
