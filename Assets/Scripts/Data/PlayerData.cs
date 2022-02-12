using Sirenix.OdinInspector;
using UnityEngine;

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
        
        
        public void Serialize() // send to DB
        {
            
        }

        public void Deserialize() // take from DB
        {
            hasBeenCached = true;
        }
    }
}
