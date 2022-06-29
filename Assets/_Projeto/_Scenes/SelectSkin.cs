using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Icypeak.Orbit.Scene
{
    public class SelectSkin : MonoBehaviour
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
