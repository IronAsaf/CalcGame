using System;
using System.Collections.Generic;
using FunctionCreator;
using Global;
using UnityEngine;
using Utility;

/*
 * Total Tetris Game Data handler, there should be one of this basically.
 * It will hold all that Tetris game rounds, functions, and whatever else that is needed.
 * It will sit inside the player Data.
 */

namespace Data
{
    [CreateAssetMenu(menuName = "GameData/Tetris Data")]
    public class TetrisData : GameData
    {
        [SerializeField] public List<TetrisFunctionData> allFunctions; // enter by hand.
        [SerializeField] public List<TetrisRoundData> allRounds;
        
        protected override void Awake()
        {
            base.Awake();
            allRounds = new List<TetrisRoundData>();
        }

        protected override void ClearData()
        {
            base.ClearData();
            allRounds = new List<TetrisRoundData>();
        }

        public void AddRound(TetrisRoundData round, TetrisFunctionData function)
        {
            allRounds.Add(round);
            timesPlayedGame++;
            function.EndGameUpdate(round.didPlayerWinRound,round.playerScore, round.timeSpentPlaying);
            if (round.didPlayerWinRound) winLoseVector.x++;
            else winLoseVector.y++;

            totalWinLoseRatio = winLoseVector.x / 1f * timesPlayedGame;
            totalTimeSpentPlaying += round.timeSpentPlaying;
        }

        public TetrisFunctionData GetCurrentFunctionData(FunctionUtility.FunctionNames functionName)
        {
            foreach (var function in allFunctions)
            {
                if (function.functionName == functionName)
                    return function;
            }
            Debug.LogError("Could not find TetrisFunctionData given name as " + functionName);
            return null;
        }

        public LevelMaker GetCurrentLevel(string nameOfLevel)
        {
            Debug.Log("I have " + GameHandler.Instance.levelsList.Count + " levels in me.");
            for (int i = 0; i < GameHandler.Instance.levelsList.Count; i++)
            {
                if (String.Equals(GameHandler.Instance.levelsList[i].levelName, nameOfLevel))
                {
                    return GameHandler.Instance.levelsList[i];
                }
            }
            Debug.LogWarning("Did not find Level");
            return GameHandler.Instance.levelsList[0];
        }
    }
}
