using System;
using UnityEngine;

using com.Icypeak.Orbit.Manager;
using com.Icypeak.Orbit.Obstacle;

namespace com.Icypeak.Orbit.Player
{
    public class PlayerStats : MonoBehaviour
    {
        Rigidbody2D _rb;

        [SerializeField] float verticalMoveSpeed;
        [SerializeField] int maxLife = 3;
        [SerializeField] int life = 3;

        public Action<int> OnLifeChange;
        public Action OnDeath;

        void Awake() => _rb = GetComponent<Rigidbody2D>();

        void Start() =>
            _rb.velocity = new Vector2(_rb.velocity.x, verticalMoveSpeed);

        void FixedUpdate()
        {
            if (transform.position.y >= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
            }
        }

        private void ReduceLife()
        {
            life--;
            OnLifeChange?.Invoke(life);
            if (life <= 0)
            {
                OnDeath?.Invoke();
                AdManager.Instance.ShowRewardedInterstitialAd();
                this.gameObject.SetActive(false);
            }
        }
        private void IncreaseLife()
        {
            life = Mathf.Clamp(life + 1, 0, maxLife);
            OnLifeChange?.Invoke(life);
        }

        void OnEnable()
        {
            if (Director.GameMode == 1)
            {
                ObstacleBehaviour.OnEscape += ReduceLife;
            }
            else
            {
                ObstacleBehaviour.OnDeath += ReduceLife;
            }
        }
        void OnDisable()
        {
            if (Director.GameMode == 1)
            {
                ObstacleBehaviour.OnEscape -= ReduceLife;
            }
            else
            {
                ObstacleBehaviour.OnDeath -= ReduceLife;
            }
        }
    }
}
