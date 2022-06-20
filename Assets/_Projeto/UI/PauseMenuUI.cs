using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Icypeak.Orbit.UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        public static Action OnGameResumed;

        public void ResumeButtonClick()
        {
            Time.timeScale = 1;
            OnGameResumed?.Invoke();
        }

        public void RestartGameButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
