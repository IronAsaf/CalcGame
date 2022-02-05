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


        public void CacheData()
        {
            
        }
    }
}
