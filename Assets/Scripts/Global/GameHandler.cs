using Data;
using Unity.Collections;
using UnityEngine;
using Utility;

namespace Global
{
    public class GameHandler : Singleton<GameHandler>
    {
        [ReadOnly] public PlayerData playerData; // make a reset functionality instead.
        [SerializeField] private PlayerData playerInfo;

        protected override void Awake()
        {
            base.Awake();
            playerData = Instantiate(playerInfo);
            DontDestroyOnLoad(this);
        }

        public PlayerData GetPlayerData()
        {
            return playerInfo;
        }
    }
}