using UnityEngine;

namespace Global
{
    public class DebugHandler : MonoBehaviour
    {
        [SerializeField] private bool timeStopActive = false;
        [SerializeField] private float timeScaleDownAmplify = 2f;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TimeStop();
                Debug.Log($"<color=#ffff33>Time Stopper</color>");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                TimeManipulation(false);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                TimeManipulation();
            }
            
            if(Input.GetKeyDown(KeyCode.N) && Input.GetKey(KeyCode.R))
            {
                OnDestroy();
            }
        }

        private void TimeStop()
        {
            if (timeStopActive)
            {
                Time.timeScale = 1f;
                timeStopActive = false;
            }
            else
            {
                Time.timeScale = 0f;
                timeStopActive = true;
            }
        }

        private void TimeManipulation(bool scaleUp = true)
        {
            if (scaleUp)
            {
                Time.timeScale *= timeScaleDownAmplify;
            }
            else
            {
                Time.timeScale /= timeScaleDownAmplify;
            }
            
        }

        private void OnDestroy()
        {
            GameHandler.Instance.isDebugModeActive = false;
            Destroy(gameObject);
        }
    }
}
