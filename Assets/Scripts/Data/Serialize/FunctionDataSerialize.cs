using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace Data.Serialize
{
    public class FunctionDataSerialize
    {
        public FunctionUtility.FunctionNames functionName;
        public int totalGamesPlayedWithThisFunction;
        public float totalTimePlayedWithThisFunction;
        public Vector2Int winLose = Vector2Int.zero;
        public float winLostRatioWithFunction;
        public int maxScoreWithFunction;
        public int minScoreWithFunction;
        public float averageScoreWithFunction;
        public List<int> totalScoreGathered;

        public FunctionDataSerialize()
        {
            functionName = FunctionUtility.FunctionNames.Abs;
            totalGamesPlayedWithThisFunction = 0;
            totalTimePlayedWithThisFunction = 0f;
            winLose = Vector2Int.zero;
            winLostRatioWithFunction = 0f;
            maxScoreWithFunction = 0;
            minScoreWithFunction = 0;
            averageScoreWithFunction = 0f;
            totalScoreGathered = new List<int>();
        }
        
        public FunctionDataSerialize(FunctionUtility.FunctionNames functionName, int totalGamesPlayedWithThisFunction, float totalTimePlayedWithThisFunction, float winLostRatioWithFunction, int maxScoreWithFunction, int minScoreWithFunction, float averageScoreWithFunction, List<int> totalScoreGathered)
        {
            this.functionName = functionName;
            this.totalGamesPlayedWithThisFunction = totalGamesPlayedWithThisFunction;
            this.totalTimePlayedWithThisFunction = totalTimePlayedWithThisFunction;
            this.winLostRatioWithFunction = winLostRatioWithFunction;
            this.maxScoreWithFunction = maxScoreWithFunction;
            this.minScoreWithFunction = minScoreWithFunction;
            this.averageScoreWithFunction = averageScoreWithFunction;
            this.totalScoreGathered = totalScoreGathered;
        }

        public FunctionDataSerialize(TetrisFunctionData data)
        {
            functionName = data.functionName;
            totalGamesPlayedWithThisFunction = data.totalGamesPlayedWithThisFunction;
            totalTimePlayedWithThisFunction = data.totalTimePlayedWithThisFunction;
            winLose = data.winLose;
            winLostRatioWithFunction = data.winLostRatioWithFunction;
            maxScoreWithFunction = data.maxScoreWithFunction;
            minScoreWithFunction = data.minScoreWithFunction;
            averageScoreWithFunction = data.averageScoreWithFunction;
            totalScoreGathered = data.totalScoreGathered.ToList();
        }
    }
}
