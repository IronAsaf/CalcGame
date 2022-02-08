using System.Collections.Generic;
using System.Globalization;
using Global;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerInfoUI : MonoBehaviour
    {
        [Space] [Title("Player Info")]
        [SerializeField] private TMP_Text playerName;
        [SerializeField] private Image playerImage;
        
        [Space] [Title("General Information")]
        [SerializeField] private TMP_Text totalWinLoseRatio;
        [SerializeField] private TMP_Text amountOfGamesPlayed;
        [SerializeField] private TMP_Text totalTimePlayed;
        
        [Space] [Title("Level Information")]
        [SerializeField] private TMP_Text levelName;
        [SerializeField] private TMP_Text passFail;

        [Space] [Title("Functions UI Listing")]
        [SerializeField] private List<FunctionUIDisplay> displayedFunctions;

        private void Awake()
        {
            var pData = GameHandler.Instance.playerData;
            playerName.text = pData.playerName;
            playerImage.sprite = pData.playerAvatar;

            var tetris = pData.tetrisGameData;
            totalWinLoseRatio.text = tetris.totalWinLoseRatio.ToString(CultureInfo.CurrentCulture);
            amountOfGamesPlayed.text = "0"; //placeholder
            totalTimePlayed.text = tetris.totalTimeSpentPlaying.ToString(CultureInfo.CurrentCulture);
            
            //check the FunctionUIDisplay length versus the player data tetris function length thing.
            //todo
        }

        private void SetupFunctionUI()
        {
            var tetris = GameHandler.Instance.playerData.tetrisGameData;
            foreach (var function in displayedFunctions)
            {
                //function.functionName 
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
