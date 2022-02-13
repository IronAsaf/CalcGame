using System.Collections.Generic;
using FunctionCreator;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace Data
{
    public abstract class GameData : SerializedScriptableObject
    {
        public string gameName;
        public int timesPlayedGame;
        public float totalWinLoseRatio;
        internal GeneralUtility.WinLose winLoseVector; // x = win, y = lose.
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
