using System.Collections.Generic;
using System.Globalization;
using Global;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class PlayerInfoUI : MonoBehaviour
    {
        [Title("General Controls")]
        [SerializeField] private Canvas uiCanvas;
        [SerializeField] private GameObject loginPopup;
        
        [Space] [Title("Player Info")]
        [SerializeField] private TMP_Text playerName;
        [SerializeField] private Image playerImage;
        
        [Space] [Title("General Information")]
        [SerializeField] private TMP_Text totalWinLoseRatio;
        [SerializeField] private TMP_Text amountOfGamesPlayed;
        [SerializeField] private TMP_Text totalTimePlayed;
        
        [Space] [Title("Level Information")]
        [SerializeField] private TMP_Text levelName;
        [SerializeField] private TMP_Text levelDifficulty;
        [SerializeField] private TMP_Text passFail;

        [Space] [Title("Functions UI Listing")]
        [SerializeField] private List<FunctionUIDisplay> displayedFunctions;

        private void Awake()
        {
            loginPopup.SetActive(true);
            uiCanvas.gameObject.SetActive(false);
        }

        public void PlayerRegister()
        {
            //for the popup thing, check if the name is taken, take data, etc etc.
        }
        public void ShowPlayerUI()
        {
            uiCanvas.gameObject.SetActive(true);
            
            var pData = GameHandler.Instance.playerData;
            playerName.text = pData.playerName;
            playerImage.sprite = pData.playerAvatar;

            var tetris = pData.tetrisGameData;
            totalWinLoseRatio.text = tetris.totalWinLoseRatio.ToString(CultureInfo.CurrentCulture);
            amountOfGamesPlayed.text = tetris.timesPlayedGame.ToString();
            totalTimePlayed.text = tetris.totalTimeSpentPlaying.ToString(CultureInfo.CurrentCulture);

            var level = tetris.GetCurrentLevel("Level 1");
            levelName.text = level.levelName;
            levelDifficulty.text = level.difficulty.ToString();
            passFail.text = level.levelComplete ? "Completed Level" : "Level incomplete";
        }
        
        private void SetupFunctionUI()
        {
            var tetris = GameHandler.Instance.playerData.tetrisGameData;
            for (var i = 0; i < tetris.allFunctions.Count; i++)
            {
                var funcData = tetris.allFunctions[i];
                foreach (var function in displayedFunctions)
                {
                    function.functionName.text = funcData.functionName.ToString();
                    function.totalTimePlayed.text = funcData.GetTotalTimePlayedWithThisFunction().ToString(CultureInfo.InvariantCulture);
                    function.winLoseRatio.text = funcData.GetWinLostRatioWithFunction().ToString(CultureInfo.InvariantCulture);
                    function.amountOfFunctionAppearance.text = funcData.GetTotalGamesPlayedWithThisFunction().ToString();
                }
            }
        }
        
    }

    [System.Serializable]
    public class FunctionUIDisplay
    {
        [SerializeField] internal TMP_Text functionName;
        [SerializeField] internal TMP_Text totalTimePlayed;
        [SerializeField] internal TMP_Text winLoseRatio;
        [SerializeField] internal TMP_Text amountOfFunctionAppearance;
    }
    
}
