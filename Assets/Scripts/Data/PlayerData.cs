using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using Sirenix.Serialization;

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
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            
            //var t = JsonConvert.SerializeObject(this,jsonSerializerSettings);
            //Debug.Log(t);
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    {"Data", JsonConvert.SerializeObject(this, jsonSerializerSettings)}
                }
            };
            PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
        }

        private void OnDataSend(UpdateUserDataResult res)
        {
            Debug.Log("I havea  reuslts");
        }
        private void OnError(PlayFabError error)
        {
            Debug.LogError("Error on PlayFab Login -- \n" + error.GenerateErrorReport());
        }
        
        [Button("Deserialize")]
        public void Deserialize() // take from DB
        {
            hasBeenCached = true;
            
            PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
        }

        private void OnDataRecieved(GetUserDataResult result)
        {
            if (result.Data != null && result.Data.ContainsKey("Data"))
            {
                PlayerData da = CreateInstance<PlayerData>();
                da = JsonConvert.DeserializeObject<PlayerData>(result.Data["Data"].Value);
                score = da.score;
                playerName = da.playerName;
                name = da.name;
                hasLoggedIn = da.hasLoggedIn;
                hasBeenCached = da.hasBeenCached;
                tetrisGameData = da.tetrisGameData;
            }
        }
        

    }
}
