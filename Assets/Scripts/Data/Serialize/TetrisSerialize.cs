using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.Serialize
{
    /*
     * Class to save the data in a JSON way. This is because the ScriptableObject doesn't serialize good in JSON.
     * This is to save the Tetris Game data itself, how many times played and all that.
     */
    public class TetrisSerialize
    {
        public string gameName;
        public int timesPlayedGame;
        public float totalWinLoseRatio;
        public Vector2Int winLoseVector;
        public float totalTimeSpentPlaying;
        public List<FunctionDataSerialize> allFunctions;
        public List<TetrisRoundData> allRounds;

        public TetrisSerialize()
        {
            gameName = "";
            timesPlayedGame = 0;
            totalWinLoseRatio = 0f;
            winLoseVector = Vector2Int.zero;
            totalTimeSpentPlaying = 0f;
            allFunctions = new List<FunctionDataSerialize>();
            allRounds = new List<TetrisRoundData>();
        }
        
        
        public TetrisSerialize(string gameName, int timesPlayedGame, float totalWinLoseRatio, Vector2Int winLoseVector, float totalTimeSpentPlaying, List<FunctionDataSerialize> allFunctions, List<TetrisRoundData> allRounds)
        {
            this.gameName = gameName;
            this.timesPlayedGame = timesPlayedGame;
            this.totalWinLoseRatio = totalWinLoseRatio;
            this.winLoseVector = winLoseVector;
            this.totalTimeSpentPlaying = totalTimeSpentPlaying;
            this.allFunctions = allFunctions.ToList();
            this.allRounds = allRounds.ToList();
        }

        public TetrisSerialize(TetrisData data)
        {
            gameName = data.gameName;
            timesPlayedGame = data.timesPlayedGame;
            totalWinLoseRatio = data.totalWinLoseRatio;
            winLoseVector = data.winLoseVector;
            totalTimeSpentPlaying = data.totalTimeSpentPlaying;
            allRounds = data.allRounds.ToList();
            allFunctions = new List<FunctionDataSerialize>();
            for (var i =0; i < data.allFunctions.Count; i++)
            {
                allFunctions.Add(new FunctionDataSerialize(data.allFunctions[i]));
            }
        }
    }
}
