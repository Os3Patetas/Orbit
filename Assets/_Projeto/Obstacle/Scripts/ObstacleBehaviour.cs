using UnityEngine;
using System;
using com.Icypeak.Orbit.Manager;
using com.Icypeak.Orbit.General;

namespace com.Icypeak.Orbit.Obstacle
{
    public class ObstacleBehaviour : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Skin selectedSkin;

        public static Action OnDeath;
        public static Action OnEscape;

        void Start()
        {
            GetComponent<SpriteRenderer>().sprite = selectedSkin.InitialSprite;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -DifficultyManager.Instance.ObstacleTargetSpeed, 0);
        }

        void Update()
        {
            transform.Rotate(0, 0, selectedSkin.RotationSpeed * Time.timeScale, Space.Self);

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
