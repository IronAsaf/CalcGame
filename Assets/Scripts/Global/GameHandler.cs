using Data;
using Unity.Collections;
using UnityEngine;
using Utility;

/*
 * This class is responsible for the wellbeing of the project itself.
 * playerdata, logins, etc etc. All will be here. 
 */

namespace Global
{
    public class GameHandler : Singleton<GameHandler>
    {
        [ReadOnly] public PlayerData playerData; // make a reset functionality instead.
        [SerializeField] private PlayerData playerInfo;
        public bool isDebugModeActive;
        public GameObject debugger;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N) && Input.GetKey(KeyCode.D) && !isDebugModeActive)
            {
                Instantiate(debugger, Instance.transform);
                isDebugModeActive = true;
            }
        }
    }
}