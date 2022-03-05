using UnityEngine;
using Utility;

namespace Tetris
{
    public class FtueTetris : MonoBehaviour
    {
        public GameObject[] toDisable;
        public GameObject[] ftueScreens;
        private int index;
        // Start is called before the first frame update
        void Awake()
        {
            if (PlayerUtility.hasSeenFtue)
            {
                gameObject.SetActive(false);
                enabled = false;
            }
        }

        private void Start()
        {
            if (PlayerUtility.hasSeenFtue) return; //idk

            foreach (var go in toDisable)
            {
                go.SetActive(false);
            }
            ftueScreens[0].SetActive(true);
            Time.timeScale = 0f;
        }
    
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) //LMB
            {
                ShowNext();
            }
        }

        private void ShowNext()
        {
            index++;
            if (index < ftueScreens.Length)
            {
                ftueScreens[index-1].SetActive(false);
                ftueScreens[index].SetActive(true);
            }
            else
            {
                DoneFtue();
            }
        
        }

        private void DoneFtue()
        {
            foreach (var go in ftueScreens)
            {
                go.SetActive(false);
            }

            foreach (var g in toDisable)
            {
                g.SetActive(true);
            }

            PlayerUtility.hasSeenFtue = true;
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            enabled = false;
        }
    }
}
