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
        [SerializeField] private Vector2Int winLose = new Vector2Int(0, 0); // x = win, y = lose.
        [SerializeField] private float winLostRatioWithFunction;
        [SerializeField] private int maxScoreWithFunction;
        [SerializeField] private int minScoreWithFunction;
        [SerializeField] private float averageScoreWithFunction;
        [SerializeField] private List<int> totalScoreGathered;
        
        [Button(name:"Clear Data")]
        public void ClearData()
        {
            totalGamesPlayedWithThisFunction = 0;
            winLostRatioWithFunction = 0f;
            maxScoreWithFunction = 0;
            minScoreWithFunction = 0;
            averageScoreWithFunction = 0;
            winLose = Vector2Int.zero;
            totalScoreGathered = new List<int>();
        }
        
        public void EndGameUpdate(bool didPlayerWin, int score) // called at end game.
        {
            totalGamesPlayedWithThisFunction++;
            UpdateWinLoseRatio(didPlayerWin);
            UpdateScore(score);
        }
        private void UpdateWinLoseRatio(bool didPlayerWin)
        {
            if (didPlayerWin) winLose.x++;
            else winLose.y++;
            winLostRatioWithFunction = winLose.x*1f / totalGamesPlayedWithThisFunction;
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
