using System;
using UnityEngine;
using TMPro;
using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.UI
{
    public class GameUI : MonoBehaviour
    {
        public static Action OnGamePaused;

        [SerializeField] TextMeshProUGUI scoreTextComponent;

        public void PauseButtonClick()
        {
            Time.timeScale = 0;
            OnGamePaused?.Invoke();
        }

        private void UpdateScoreText(int score) => scoreTextComponent.text = score.ToString();

        void OnEnable() => PlayerStats.OnScoreChange += UpdateScoreText;
        void OnDisable() => PlayerStats.OnScoreChange -= UpdateScoreText;
    }
}
