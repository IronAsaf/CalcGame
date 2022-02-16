using System;
using UnityEngine;

namespace Utility
{
    public static class GeneralUtility
    {
        [Serializable]
        public struct WinLose
        {
            public int win;
            public int lose;
        }
        
        public static T CreateFromJSON<T>(string jsonString)
        {
            return JsonUtility.FromJson<T>(jsonString);
        }
        
        public static string CreateToJSON<T>(T toSave)
        {
            return JsonUtility.ToJson(toSave);
        }

        public static void AdjustTimeScale(float towards = 1f)
        {
            Time.timeScale = towards;
        }
    }
}
