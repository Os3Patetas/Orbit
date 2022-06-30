using com.Icypeak.Orbit.Manager;
using UnityEngine;

namespace com.Icypeak.Orbit
{
    public class HeartContainer : MonoBehaviour
    {
        public int HeartContainerNumber;

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

        private void OnEnable()
        {
            PlayerManager.Instance.playerStats.OnLifeChange += RefreshHeartContainer;
        }
        private void OnDisable()
        {
            PlayerManager.Instance.playerStats.OnLifeChange -= RefreshHeartContainer;
        }
    }
}
