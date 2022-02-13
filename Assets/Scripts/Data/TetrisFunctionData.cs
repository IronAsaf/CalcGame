using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace Data
{
    /*
     * This script is a data capsule that handles the occurence of X^2 or something like that in the game.
     * How well did the player do with this function around.
     * And so on.
     */
    [CreateAssetMenu(menuName = "GameData/Tetris Function Data")]
    public class TetrisFunctionData : SerializedScriptableObject
    {
        public FunctionUtility.FunctionNames functionName;
        [SerializeField] private int totalGamesPlayedWithThisFunction;
        [SerializeField] private float totalTimePlayedWithThisFunction;
        [SerializeField] private GeneralUtility.WinLose winLose = new(){win = 0, lose = 0};
        [SerializeField] private float winLostRatioWithFunction;
        [SerializeField] private int maxScoreWithFunction;
        [SerializeField] private int minScoreWithFunction;
        [SerializeField] private float averageScoreWithFunction;
        [SerializeField] private List<int> totalScoreGathered;

        public int GetTotalGamesPlayedWithThisFunction() => totalGamesPlayedWithThisFunction;
        public float GetWinLostRatioWithFunction() => winLostRatioWithFunction;
        public float GetTotalTimePlayedWithThisFunction() => totalTimePlayedWithThisFunction;
        
        [Button(name:"Clear Data")]
        public void ClearData()
        {
            totalTimePlayedWithThisFunction = 0f;
            totalGamesPlayedWithThisFunction = 0;
            winLostRatioWithFunction = 0f;
            maxScoreWithFunction = 0;
            minScoreWithFunction = 0;
            averageScoreWithFunction = 0;
            winLose = new(){win = 0, lose = 0};
            totalScoreGathered = new List<int>();
        }
        
        public void EndGameUpdate(bool didPlayerWin, int score, float time) // called at end game.
        {
            totalTimePlayedWithThisFunction += time;
            totalGamesPlayedWithThisFunction++;
            UpdateWinLoseRatio(didPlayerWin);
            UpdateScore(score);
        }
        private void UpdateWinLoseRatio(bool didPlayerWin)
        {
            if (didPlayerWin) winLose.win++;
            else winLose.lose++;
            winLostRatioWithFunction = winLose.win*1f / totalGamesPlayedWithThisFunction;
        }

        private void UpdateScore(int score)
        {
            totalScoreGathered.Add(score);
            maxScoreWithFunction = totalScoreGathered.Max();
            minScoreWithFunction = totalScoreGathered.Min();
            averageScoreWithFunction = totalScoreGathered.Sum()*1f / totalGamesPlayedWithThisFunction;
        }
    }
}
