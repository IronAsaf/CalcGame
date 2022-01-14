using System.Collections;
using Data;
using UI;
using Unity.Collections;
using UnityEngine;

namespace Global
{
    public class GameHandler : MonoBehaviour
    {
        [ReadOnly] public PlayerData playerData;
        [SerializeField] private PlayerData playerInfo;
        [SerializeField] private float timeScale = 1f;
        [SerializeField] private int scoreStart = 10000;
        [SerializeField] private float scoreConstraint = 0.05f;
        private void Awake()
        {
            playerData = Instantiate(playerInfo);
            TimeController();
        }

        private void Start()
        {
            StartCoroutine(GameScore());
            UiManager.Instance.UpdateScore(scoreStart);
        }

        private IEnumerator GameScore()
        {
            while (scoreStart >= 0)
            {
                yield return new WaitForSeconds(scoreConstraint);
                scoreStart -= 1;
                UiManager.Instance.UpdateScore(scoreStart);
            }
            
            //ENDGAME out of score...
        }
        private void TimeController(float newTimer = -1f)
        {
            if (newTimer < 0f)
            {
                Time.timeScale = timeScale;
            }
            else
            {
                Time.timeScale = newTimer;
                timeScale = newTimer;
            }
        }
        

        public void EndGame()
        {
            
        }
    }
}