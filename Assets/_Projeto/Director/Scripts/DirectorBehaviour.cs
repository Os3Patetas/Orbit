using UnityEngine;
using com.Icypeak.Orbit.UI;

namespace com.Icypeak.Orbit.Director
{
    public class DirectorBehaviour : MonoBehaviour
    {
        public GameObject GameUIObj;
        public GameObject PauseMenuUIObj;

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
