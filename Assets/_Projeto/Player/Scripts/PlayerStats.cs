using System;
using System.Collections;
using UnityEngine;
using com.Icypeak.Orbit.Manager;
using com.Icypeak.Orbit.Obstacle;

namespace com.Icypeak.Orbit.Player
{
    public class PlayerStats : MonoBehaviour
    {
        //Components
        Rigidbody2D _rb;
        
        [Header("Stats")]
        [SerializeField] float verticalMoveSpeed;
        [SerializeField] int maxLife = 3;
        [SerializeField] int life = 3;
        [SerializeField] float invincibilityDuration;

        //Delegates
        public Action<int> OnLifeChange;
        public Action OnDeath;

        //Status
        bool _isInvincible;

        void Awake() => _rb = GetComponent<Rigidbody2D>();

        void Start()
        {
            _isInvincible = false;
            _rb.velocity = new Vector2(_rb.velocity.x, verticalMoveSpeed);
        }

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
            if (!_isInvincible)
            {
                life--;
                OnLifeChange?.Invoke(life);
                if (life <= 0)
                {
                    OnDeath?.Invoke();
                    this.gameObject.SetActive(false);
                }
            }
        }

        public void IncreaseLife()
        {
            life = Mathf.Clamp(life + 1, 0, maxLife);
            OnLifeChange?.Invoke(life);
        }

        private IEnumerator StartInvincibilityTimer()
        {
            _isInvincible = true;
            yield return new WaitForSeconds(invincibilityDuration);
            _isInvincible = false;
        }

        public void BecomeInvincibile()
        {
            StartCoroutine(StartInvincibilityTimer());
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
