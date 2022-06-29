using UnityEngine;
using UnityEngine.SceneManagement;

using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.Scene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject endGameUI;
        [SerializeField] PlayerStats playerStats;
        public void OpenPauseMenuButton()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        public void ResumeButton()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        public void RestartButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void GoToMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }

        public void ActivateEndGameUI()
        {
            Time.timeScale = 0;
            endGameUI.SetActive(true);
        }

        private void OnEnable()
        {
            playerStats.OnDeath += ActivateEndGameUI;
        }
        private void OnDisable()
        {
            playerStats.OnDeath -= ActivateEndGameUI;
        }
    }
}
