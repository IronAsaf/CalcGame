using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;

namespace Data
{
    [CreateAssetMenu(menuName = "CalcGame/Player Data", fileName = "PlayerName")]
    public class PlayerData : ScriptableObject
    { 
        public string playerName;
        public float score;
        public TetrisData tetrisGameData;
        public bool hasLoggedIn;
        public bool hasBeenCached;
        
        [Button("Serialize test")]
        public void Serialize() // send to DB
        {
            var t = JsonConvert.SerializeObject(this);
            Debug.Log(t);
            /*var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    {"Data", JsonConvert.SerializeObject(this)}
                }
            };
            PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);*/
        }

        private void OnDataSend(UpdateUserDataResult res)
        {
            Debug.Log("I havea  reuslts");
        }
        private void OnError(PlayFabError error)
        {
            Debug.LogError("Error on PlayFab Login -- \n" + error.GenerateErrorReport());
        }
        public void Deserialize() // take from DB
        {
            hasBeenCached = true;
        }
        

    }
}
