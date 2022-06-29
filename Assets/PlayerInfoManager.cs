using UnityEngine;

using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.Manager
{
    public class PlayerInfoManager : MonoBehaviour
    {
        public static PlayerInfoManager Instance;

        public PlayerInfo playerInfo;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
            playerInfo = Resources.Load<PlayerInfo>("Player/PlayerInfo");
        }

    }
}
