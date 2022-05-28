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
        [SerializeField] GameObject[] heartFill;

        public void PauseButtonClick()
        {
            Time.timeScale = 0;
            OnGamePaused?.Invoke();
        }

        private void UpdateScoreText(int score) => scoreTextComponent.text = score.ToString();

        void OnEnable()
        {
            PlayerStats.OnScoreChange += UpdateScoreText;
            PlayerStats.OnLifeChange += UpdateHeartContainer;
        }


        void OnDisable()
        {
            PlayerStats.OnScoreChange -= UpdateScoreText;
            PlayerStats.OnLifeChange -= UpdateHeartContainer;
        }

        void UpdateHeartContainer(int Lifes)
        {
            switch (Lifes)
            {
                case 0:
                    heartFill[0].SetActive(false);
                    heartFill[1].SetActive(false);
                    heartFill[2].SetActive(false);
                    break;

                case 1:
                    heartFill[0].SetActive(true);
                    heartFill[1].SetActive(false);
                    heartFill[2].SetActive(false);
                    break;

                case 2:
                    heartFill[0].SetActive(true);
                    heartFill[1].SetActive(true);
                    heartFill[2].SetActive(false);
                    break;

                case 3:
                    heartFill[0].SetActive(true);
                    heartFill[1].SetActive(true);
                    heartFill[2].SetActive(true);
                    break;
            }
        }
    }
}
