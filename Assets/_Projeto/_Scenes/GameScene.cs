using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Icypeak.Orbit.Scene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] GameObject PauseMenu;
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
    }
}
