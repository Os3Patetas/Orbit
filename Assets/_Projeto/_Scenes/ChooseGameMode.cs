using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Icypeak.Orbit.Scene
{
    public class ChooseGameMode : MonoBehaviour
    {
        public void GoToDestroyMode()
        {
            SceneManager.LoadScene("DestroyMode");
        }

        public void GoToSurviveMode()
        {
            SceneManager.LoadScene("SurviveMode");
        }
        
        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
