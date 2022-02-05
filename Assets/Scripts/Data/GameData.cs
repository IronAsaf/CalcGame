using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Data
{
    public abstract class GameData : SerializedScriptableObject
    {
        public string gameName;
        public int timesPlayedGame;
        public float totalWinLoseRatio;
        public List<IGameRoundData> gameRounds;

        protected virtual void Awake()
        {
            gameRounds = new List<IGameRoundData>();
        }

        protected virtual void ClearData()
        {
            gameRounds = new List<IGameRoundData>();
            totalWinLoseRatio = 0f;
            timesPlayedGame = 0;
        }
    }
}
