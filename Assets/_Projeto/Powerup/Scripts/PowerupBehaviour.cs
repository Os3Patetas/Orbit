using System;

using UnityEngine;

using com.Icypeak.Orbit.Player;
using com.Icypeak.Orbit.Utils;

namespace com.Icypeak.Orbit.Powerup
{
    public class PowerupBehaviour : MonoBehaviour
    {
        protected Rigidbody2D _rb;
        protected SpriteRenderer _sr;

        [SerializeField] protected float verticalSpeed;
        [SerializeField] protected float maxVerticalSpeed;
        [SerializeField] protected float rotationSpeed;

        [SerializeField] protected Skin selectedSkin;

        void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            _sr.sprite = selectedSkin.InitialSprite;
            rotationSpeed = verticalSpeed * selectedSkin.RotationSpeed / 2;

            _rb.velocity = new Vector3(0, -verticalSpeed, 0);
        }

        void Update()
        {
            transform.Rotate(0, 0, rotationSpeed * Time.timeScale, Space.Self);

            if (transform.position.y <= -6)
                Die();
        }

        protected void Die() => Destroy(this.gameObject);

        void OnEnable() => PlayerStats.OnDeath += Die;
        void OnDisable() => PlayerStats.OnDeath -= Die;
    }
}
