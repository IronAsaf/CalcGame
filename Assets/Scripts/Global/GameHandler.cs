using Data;
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
        
        [Title("Player Data")]
        public PlayerData playerData; // make a reset functionality instead.
        
        [Title("Ongoing Information")]
        public bool isDebugModeActive;
        public GameObject debugger;
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);

            if (playerData.hasLoggedIn) return;
            loginPopup.DisplayLogin();
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