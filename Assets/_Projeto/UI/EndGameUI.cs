using UnityEngine;
using TMPro;
using com.Icypeak.Orbit.Manager;
using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scorePointsText;
        [SerializeField] TextMeshProUGUI scoreCoinsText;
        [SerializeField] TextMeshProUGUI bonusCoinsText;
        [SerializeField] TextMeshProUGUI totalCoinsText;
        [SerializeField] TextMeshProUGUI currentCoinsText;

        private void OnEnable()
        {
            var score = FindObjectOfType<ScoreManager>().ScorePoints;
            var playerInfo = Resources.Load<PlayerInfo>("Player/PlayerInfo");

            var scoreCoins = score / 10.0f;
            var bonusPercentage = ((int)playerInfo.activatedBonus.type / 100.0f);
            var bonusCoins = score * bonusPercentage;

            scorePointsText.text = score.ToString();
            scoreCoinsText.text = $"Score Coins: + {(int)scoreCoins}";
            bonusCoinsText.text = $"Bonus({bonusPercentage}x): {bonusCoins}";
            totalCoinsText.text = $"Total Earned: {(int)(scoreCoins + bonusCoins)}";
            currentCoinsText.text = $"Coins: {(int)(playerInfo.coins + scoreCoins + bonusCoins)}";
        }
    }
}
