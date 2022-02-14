using System;
using Global;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Utility;

namespace Data.PlayFabConnect
{
    public class PlayFabManager : MonoBehaviour
    {
        public void Login()
        {
            if (!PlayerUtility.gatherData) return;
            var req = new LoginWithCustomIDRequest
            {
                CustomId = SystemInfo.deviceUniqueIdentifier,
                CreateAccount = true
            };
            PlayFabClientAPI.LoginWithCustomID(req,OnSuccess,OnError);
        }

        private void OnSuccess(LoginResult res)
        {
            Debug.Log("PlayFab Logged in!");
            GameHandler.Instance.playerData.Deserialize();
        }

        private void OnError(PlayFabError error)
        {
            Debug.LogError("Error on PlayFab Login -- \n" + error.GenerateErrorReport());
        }
    }
}
