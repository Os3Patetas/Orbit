using UnityEngine;
using UnityEngine.SceneManagement;

using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.Scene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] GameObject PauseMenu;
        [SerializeField] GameObject EndGameUI;
        public void OpenPauseMenuButton()
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        public void ResumeButton()
        {
            PauseMenu.SetActive(false);
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
            EndGameUI.SetActive(true);
        }

        private void OnEnable()
        {
            FindObjectOfType<PlayerStats>().OnDeath += ActivateEndGameUI;
        }
        private void OnDisable()
        {
            FindObjectOfType<PlayerStats>().OnDeath -= ActivateEndGameUI;
        }
    }
}
