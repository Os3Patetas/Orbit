using UnityEngine;

using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        public PlayerStats playerStats;

        private void Awake()
        {
            if(Instance != this && Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    }
}
