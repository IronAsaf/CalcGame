using Sirenix.OdinInspector;
using UnityEngine;

namespace Data
{
    public abstract class GameData : SerializedScriptableObject
    {
        public string gameName;
        public int timesPlayedGame;
        public float totalWinLoseRatio;
        internal Vector2Int winLoseVector; // x = win, y = lose.
        public float totalTimeSpentPlaying;

        protected virtual void Awake()
        {

        }

        protected virtual void ClearData()
        {
            totalWinLoseRatio = 0f;
            timesPlayedGame = 0;
        }
    }
}
