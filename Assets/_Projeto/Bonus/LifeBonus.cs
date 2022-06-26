using com.Icypeak.Orbit.Player;
using UnityEngine;

namespace com.Icypeak.Orbit.Bonus
{
    public class LifeBonus : MonoBehaviour
    {
        [SerializeField] float speed;

        void Start() => GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        void Update()
        {
            if (transform.position.y <= -6)
            {
                Destroy(this.gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                coll.gameObject.GetComponent<PlayerStats>().IncreaseLife();
                Destroy(this.gameObject);
            }
        }
    }
}
