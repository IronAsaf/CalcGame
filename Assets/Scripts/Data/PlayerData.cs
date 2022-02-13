using System.Runtime.InteropServices;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace Data
{
    [CreateAssetMenu(menuName = "CalcGame/Player Data", fileName = "PlayerName")]
    public class PlayerData : SerializedScriptableObject
    {
        public Sprite playerAvatar;
        public string playerName;
        public float score;
        public TetrisData tetrisGameData;
        public bool hasLoggedIn;
        public bool hasBeenCached;
        
        [Button("Serialize test")]
        public void Serialize() // send to DB
        {
            var data = GeneralUtility.CreateToJSON(this);
            Debug.Log(data);
        }

        public void Deserialize() // take from DB
        {
            hasBeenCached = true;
        }
        

    }
}
