using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            uiCanvas.gameObject.SetActive(false);
        }

        public void ShowPlayerUI()
        {
            uiCanvas.gameObject.SetActive(true);
            
            var pData = GameHandler.Instance.playerData;
            playerName.text = pData.playerName;

            var tetris = pData.tetrisGameData;
            totalWinLoseRatio.SetText(tetris.totalWinLoseRatio.ToString(CultureInfo.InvariantCulture));
            amountOfGamesPlayed.SetText(tetris.timesPlayedGame.ToString());
            totalTimePlayed.SetText(tetris.totalTimeSpentPlaying.ToString(CultureInfo.InvariantCulture));

            var level = tetris.GetCurrentLevel("Level 1");
            levelName.text = level.levelName;
            levelDifficulty.text = level.difficulty.ToString();
            passFail.text = level.levelComplete ? "Completed Level" : "Level incomplete";

            SetupFunctionUI();
        }
        
        private void SetupFunctionUI()
        {
            var tetris = GameHandler.Instance.playerData.tetrisGameData;
            for (var i = 0; i < tetris.allFunctions.Count; i++)
            {
                var funcData = tetris.allFunctions[i];
                var function = displayedFunctions[i];
                
                function.functionName.SetText(funcData.functionName.ToString());
                function.totalTimePlayed.SetText(funcData.GetTotalTimePlayedWithThisFunction().ToString(CultureInfo.InvariantCulture));
                function.winLoseRatio.SetText(funcData.GetWinLostRatioWithFunction().ToString(CultureInfo.InvariantCulture));
                function.amountOfFunctionAppearance.SetText(funcData.GetTotalGamesPlayedWithThisFunction().ToString());
            }
        }

        public void OnClickCloseUI()
        {
            uiCanvas.gameObject.SetActive(false);
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
