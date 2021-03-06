using System.Collections.Generic;
using Data.Serialize;
using Sirenix.OdinInspector;
using UnityEngine;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using Utility;

namespace Data
{
    /*
     * This is the runtime class for player data, that will be loaded from the PlayerSerialize object.
     */
    [CreateAssetMenu(menuName = "CalcGame/Player Data", fileName = "PlayerName")]
    public class PlayerData : ScriptableObject
    { 
        public string playerName;
        public float score;
        public TetrisData tetrisGameData;
        public bool hasLoggedIn;
        public bool hasBeenCached;

        public void Setup(PlayerSerialize data)
        {
            playerName = data.playerName;
            score = data.score;
            tetrisGameData.Setup(data.tetrisGameData);
        }

        [Button("Print out Serialize")]
        public void PrintOutSerialize()
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            var data = new PlayerSerialize(this);
            var s = JsonConvert.SerializeObject(data, jsonSerializerSettings);
            Debug.Log(s);
        }
        [Button("Serialize test")]
        public void Serialize() // send to DB
        {
            if (!PlayerUtility.gatherData) return;
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            
            var data = new PlayerSerialize(this);
            //var s = JsonConvert.SerializeObject(data, jsonSerializerSettings);
            //Debug.Log(s);
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    {"Data", JsonConvert.SerializeObject(data, jsonSerializerSettings)}
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
            if (!PlayerUtility.gatherData) return;
            hasBeenCached = true;
            
            PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
        }

        private void OnDataRecieved(GetUserDataResult result)
        {
            if (result.Data != null && result.Data.ContainsKey("Data"))
            {
                var da = JsonConvert.DeserializeObject<PlayerSerialize>(result.Data["Data"].Value);
                score = da.score;
                playerName = da.playerName;
                tetrisGameData.Setup(da.tetrisGameData);
                
                Debug.Log("I am done with player setup");
            }
        }
    }
}