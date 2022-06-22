using com.Icypeak.Orbit.Player;
using UnityEngine;

namespace com.Icypeak.Orbit.Bonus
{
    public class InvincibilityBonus : MonoBehaviour
    {
        [SerializeField] float speed;

        void Start() => GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        void Update()
        {
            if(transform.position.y <= -6)
            {
                Destroy(this.gameObject);
            }    
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerStats>().BecomeInvincibile();
                Destroy(this.gameObject);
            }    
        }
    }
}
