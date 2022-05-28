using System;

using UnityEngine;

using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.Powerup
{
    public class LifePowerup : PowerupBehaviour
    {
        public static Action OnDeath;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerStats>().Lifes++;
                OnDeath?.Invoke();
                Die();
                return;
            }
        }
    }
}
