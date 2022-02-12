using System.Collections.Generic;
using FunctionCreator;
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
        [SerializeField] protected List<LevelMaker> levelsList; 
        
        
        
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
