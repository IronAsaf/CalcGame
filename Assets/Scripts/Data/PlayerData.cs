using Sirenix.OdinInspector;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "CalcGame/PLayer Data", fileName = "PlayerName")]
    public class PlayerData : SerializedScriptableObject
    {
        public Sprite playerAvatar;
        public string playerName;
        public float score;
    }
}
