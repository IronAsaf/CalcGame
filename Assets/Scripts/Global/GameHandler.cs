using System.Collections.Generic;
using Data;
using FunctionCreator;
using Sirenix.OdinInspector;
using UI.Popups;
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
        [Title("References")]
        [SerializeField] private PlayerLoginPopup loginPopup;
        [SerializeField] public List<LevelMaker> levelsList;
        [SerializeField] private List<LevelDifficulty> difficulties;
        
        [Title("Player Data")]
        public PlayerData playerData; // make a reset functionality instead.
        
        [Title("Ongoing Information")]
        public bool isDebugModeActive;
        public GameObject debugger;
        public LevelDifficulty difficulty;
        protected override void Awake()
        {
            base.Awake();
            int numMusicPlayers = FindObjectsOfType<GameHandler>().Length;
            if (numMusicPlayers != 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }

            if (!PlayerUtility.hasPlayerLoggedIn)
            {
                PlayerUtility.hasPlayerLoggedIn = true;
                loginPopup.DisplayLogin();
            }

            GeneralUtility.AdjustTimeScale();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N) && Input.GetKey(KeyCode.D) && !isDebugModeActive)
            {
                Instantiate(debugger, Instance.transform);
                isDebugModeActive = true;
            }
        }


        public void OnClickDifficultySet(int diff)
        {
            for (int i = 0; i < difficulties.Count; i++)
            {
                if (difficulties[i].difficulty.Equals((LevelDifficulty.Difficulty) diff))
                {
                    difficulty = difficulties[i];
                    return;
                }
            }

            difficulty = difficulties[0];
        }
        
    }
}