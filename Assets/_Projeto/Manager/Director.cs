using UnityEngine;
using com.Icypeak.Orbit.UI;
using UnityEngine.SceneManagement;

namespace com.Icypeak.Orbit.Manager
{
    public class Director : MonoBehaviour
    {
        public GameObject GameUIObj;
        public GameObject PauseMenuUIObj;
        public static int GameMode = 1;
        public static float ObstacleMaxSpeed;

        void Awake()
        {
            if (string.Compare(SceneManager.GetActiveScene().name, "DestroyMode") == 0)
            {
                GameMode = 1;
            }
            else
            {
                GameMode = 2;
            }
        }

        void OnEnable()
        {
            GameUI.OnGamePaused += EnablePauseMenuUI;

            PauseMenuUI.OnGameResumed += DisablePauseMenuUI;
        }

        void OnDisable()
        {
            GameUI.OnGamePaused -= EnablePauseMenuUI;

            PauseMenuUI.OnGameResumed -= DisablePauseMenuUI;
        }

        private void EnableGameUI() => GameUIObj.SetActive(true);
        private void DisableGameUI() => GameUIObj.SetActive(false);
        private void EnablePauseMenuUI() => PauseMenuUIObj.SetActive(true);
        private void DisablePauseMenuUI() => PauseMenuUIObj.SetActive(false);
    }
}
