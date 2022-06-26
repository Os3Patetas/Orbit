using UnityEngine;
using System;

namespace com.Icypeak.Orbit.Obstacle
{
    public class ObstacleBehaviour : MonoBehaviour
    {
        [SerializeField] float speed;
        public static float ScalingSpeed;
        [SerializeField] float scalingSpeedIncrement;
        [SerializeField] float maxScalingSpeed;
        //float rotationSpeed;

        public static Action OnDeath;
        public static Action OnEscape;

        void Start()
        {
            speed = ScalingSpeed;
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
                ScalingSpeed = Mathf.Clamp(ScalingSpeed + scalingSpeedIncrement, 0, maxScalingSpeed);
                Destroy(this.gameObject);
            }
        }
    }
}
