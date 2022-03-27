using Global;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Utility;

namespace Data.PlayFabConnect
{
    /*
     * This class is controlling the server side of data, saving and loading.
     * It is not complete, it is missing a user login option. For now its per Device, so on the same computer
     * you get the same data, more or less.
     * There are things here that are not totally finished.
     * To activate you need to go to Utility > PlayerUtility > gatherData = true.
     */
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
