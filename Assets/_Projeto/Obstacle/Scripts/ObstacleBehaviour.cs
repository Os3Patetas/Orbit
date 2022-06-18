using UnityEngine;
using System;
using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.Obstacle
{
    public class ObstacleBehaviour : MonoBehaviour
    {
        Rigidbody2D _rb;
        SpriteRenderer _sr;

        [SerializeField] ObstacleSkin selectedSkin;

        [SerializeField] float verticalSpeed;
        [SerializeField] float maxVerticalSpeed;
        float rotationSpeed;

        public static Action OnDeath;
        public static Action OnEscape;

        void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            _sr.sprite = selectedSkin.ObstacleSprite;
            rotationSpeed = verticalSpeed * selectedSkin.RotationSpeed / 2;

            _rb.velocity = new Vector3(0, -verticalSpeed, 0);
        }

        void Update()
        {
            transform.Rotate(0, 0, rotationSpeed * Time.timeScale, Space.Self);

            if (transform.position.y <= -6)
            {
                OnEscape?.Invoke();
                Die();
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                OnDeath?.Invoke();
                Die();
            }
        }

        void Die() => Destroy(this.gameObject);

        void OnEnable() => PlayerStats.OnDeath += Die;
        void OnDisable() => PlayerStats.OnDeath -= Die;

        void OnValidate() => rotationSpeed = verticalSpeed * selectedSkin.RotationSpeed / 2;
    }
}
