using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace Data.PlayFabConnect
{
    public class PlayFabManager : MonoBehaviour
    {
        public void Login()
        {
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
        }

        private void OnError(PlayFabError error)
        {
            Debug.LogError("Error on PlayFab Login -- \n" + error.GenerateErrorReport());
        }
    }
}
