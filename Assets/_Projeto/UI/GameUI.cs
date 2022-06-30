using System;
using UnityEngine;

namespace com.Icypeak.Orbit.UI
{
    public class GameUI : MonoBehaviour
    {
        public static Action OnGamePaused;

        public void PauseButtonClick()
        {
            Time.timeScale = 0;
            OnGamePaused?.Invoke();
        }

    }
}
