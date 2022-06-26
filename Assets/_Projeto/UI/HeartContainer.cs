using com.Icypeak.Orbit.Player;
using UnityEngine;

namespace com.Icypeak.Orbit
{
    public class HeartContainer : MonoBehaviour
    {
        public int HeartContainerNumber;
        void Start() => FindObjectOfType<PlayerStats>().OnLifeChange += RefreshHeartContainer;

        private void RefreshHeartContainer(int life)
        {
            if(life < HeartContainerNumber)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
