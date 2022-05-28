using System;
using System.Collections;

using UnityEngine;

using com.Icypeak.Orbit.Obstacle;
using com.Icypeak.Orbit.Utils;

namespace com.Icypeak.Orbit.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] Skin currentSkin;
        Rigidbody2D _rb;

        public int Score = 0;
        int lifes = 3;

        public static Action<int> OnScoreChange;
        public static Action<int> OnLifeChange;
        public static Action OnDeath;

        [SerializeField] float verticalMoveSpeed;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            GetComponent<SpriteRenderer>().sprite = currentSkin.InitialSprite;
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

        public int Lifes
        {
            get => lifes;
            set
            {
                lifes = value;
                OnLifeChange?.Invoke(Lifes);

                if (Lifes <= 0)
                {
                    OnDeath?.Invoke();
                    gameObject.SetActive(false);
                }
            }
        }

        IEnumerator InvincibilityTimer()
        {
            ObstacleBehaviour.OnEscape -= DecreaseLife;
            yield return new WaitForSeconds(5f);
            ObstacleBehaviour.OnEscape += DecreaseLife;
        }

        public void ActivateInvincibility() => StartCoroutine("InvincibilityTimer");

        void IncreaseLife() => Lifes++;
        void DecreaseLife() => Lifes--;
    }
}
