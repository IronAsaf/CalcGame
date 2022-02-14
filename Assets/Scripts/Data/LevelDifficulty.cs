using Sirenix.OdinInspector;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "CalcGame/Level Difficulty")]
    public class LevelDifficulty : ScriptableObject
    {
        public enum Difficulty
        {
            Easy, Medium, Hard
        }

        public Difficulty difficulty = Difficulty.Medium;
        public int scoreDecreaseRate = 10;
        public float speedIncreaseRate = 0.4f;
        public Vector2 speedClamp = new(0, -3.5f);
        public int baseStartingScore = 10000;
        public int minimumWinningScore = 5000;

        [Button("Reset")]
        public void Reset()
        {
            difficulty = Difficulty.Medium;
            scoreDecreaseRate = 10;
            speedIncreaseRate = 0.4f;
            speedClamp = new(0, -3.5f);
            baseStartingScore = 10000;
            minimumWinningScore = 5000;
        }
    }
}
