using System;
using UnityEngine;
using com.Icypeak.Orbit.Obstacle;

namespace com.Icypeak.Orbit.Player
{
    public class PlayerStats : MonoBehaviour
    {
        Rigidbody2D _rb;

        public int Score = 0;
        public int Lifes = 3;

        public static Action<int> OnScoreChange;
        public static Action OnLifeChange;
        public static Action OnDeath;

        [SerializeField] float verticalMoveSpeed;

        void Awake() => _rb = GetComponent<Rigidbody2D>();

        void Update()
        {
            if (Lifes <= 0)
            {
                OnDeath?.Invoke();
                gameObject.SetActive(false);
            }
        }

        void FixedUpdate()
        {
            if (transform.position.y == -3)
                _rb.velocity = new Vector2(_rb.velocity.x, verticalMoveSpeed);

            if (transform.position.y >= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
            }
        }

        void OnEnable()
        {
            ObstacleBehaviour.OnDeath += IncreaseScore;
            ObstacleBehaviour.OnEscape += DecreaseLife;
        }

        void OnDisable()
        {
            ObstacleBehaviour.OnDeath -= IncreaseScore;
            ObstacleBehaviour.OnEscape -= DecreaseLife;
        }

        void IncreaseScore()
        {
            Score++;
            OnScoreChange?.Invoke(Score);
        }

        void DecreaseLife()
        {
            Lifes--;
            OnLifeChange?.Invoke();
        }
    }
}
