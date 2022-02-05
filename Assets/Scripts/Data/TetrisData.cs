using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "GameData/Tetris Data")]
    public class TetrisData : GameData
    {
        [SerializeField] private List<TetrisFunctionData> allFunctions;
        [SerializeField] private List<TetrisRoundData> allRounds;
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void ClearData()
        {
            base.ClearData();
        }
    }
}
