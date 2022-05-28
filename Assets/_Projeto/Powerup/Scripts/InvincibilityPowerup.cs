using UnityEngine;

using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.Powerup
{
    public class InvincibilityPowerup : PowerupBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            col.gameObject.GetComponent<PlayerStats>().ActivateInvincibility();
            Destroy(this.gameObject);
        }
    }
}
