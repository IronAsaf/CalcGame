using System;
using Data;
using Data.PlayFabConnect;
using Global;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace UI.Popups
{
    public class PlayerLoginPopup : PopupHandler
    {
        [Title("Display Components")]
        [SerializeField] private Canvas loginCanvas;
        [SerializeField] private TMP_InputField login;
        [SerializeField] private PlayFabManager playFabManager;
        private PlayerData pData;

        public void DisplayLogin()
        {
            pData = GameHandler.Instance.playerData;
            loginCanvas.gameObject.SetActive(true);
            playFabManager.Login();
        }

        //By the press of the button this will be activated.
        public void PlayerRegister()
        {
            
            //for the popup thing, check if the name is taken, take data, etc etc.
            
            //check if the name is taken or new.
            
            //if new, create new playerData
            //if old, call Cache
            GameHandler.Instance.playerData.playerName = login.text;
            loginCanvas.gameObject.SetActive(false);
        }
        
        
    }
}
