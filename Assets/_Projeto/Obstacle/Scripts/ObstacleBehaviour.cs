using UnityEngine;
using System;

namespace com.Icypeak.Orbit.Obstacle
{
    public class ObstacleBehaviour : MonoBehaviour
    {
        [SerializeField] float speed;
        //float rotationSpeed;

        public static Action OnDeath;
        public static Action OnEscape;

        void Start()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);
        }

        void Update()
        {
            //transform.Rotate(0, 0, rotationSpeed * Time.timeScale, Space.Self);

            if (transform.position.y <= -6)
            {
                OnEscape?.Invoke();
                Destroy(this.gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                OnDeath?.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}
