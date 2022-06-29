using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Icypeak.Orbit.Manager
{
    public class Director : MonoBehaviour
    {
        public static int GameMode = 1;

        public static float ObstacleSpeed;

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
    }
}
