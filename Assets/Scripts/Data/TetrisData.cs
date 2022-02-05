using System.Collections.Generic;
using UnityEngine;

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
        [SerializeField] private List<TetrisFunctionData> allFunctions; // enter by hand.
        [SerializeField] private List<TetrisRoundData> allRounds;
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void ClearData()
        {
            base.ClearData();
        }

        public void AddRound(TetrisRoundData round)
        {
            //log it
            allRounds.Add(round);
        }

        public TetrisFunctionData GetCurrentFunctionData(string functionName)
        {
            foreach (var function in allFunctions)
            {
                if (function.functionName == functionName)
                    return function;
            }
            Debug.LogError("Could not find TetrisFunctionData given name as " + functionName);
            return null;
        }
    }
}
