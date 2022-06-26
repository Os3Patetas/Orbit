using System;
using UnityEngine;

using com.Icypeak.Orbit.Obstacle;

namespace com.Icypeak.Orbit.Manager
{
    public class DifficultyManager : MonoBehaviour
    {
        public static DifficultyManager Instance;

        public float ObstacleTargetSpeed;
        [SerializeField] float ObstacleInitialSpeed;
        [SerializeField] float ObstacleSpeedToAdd;
        [SerializeField] float ObstacleMaxSpeed;

        private void Awake()
        {
            if(Instance != this && Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            ObstacleTargetSpeed = ObstacleInitialSpeed;
        }

        private void IncrementSpeed()
        {
            ObstacleTargetSpeed = Mathf.Clamp(ObstacleTargetSpeed + ObstacleSpeedToAdd, 0, ObstacleMaxSpeed);
        }

        private void OnEnable() =>
            ObstacleBehaviour.OnDeath += IncrementSpeed;
        private void OnDisable() =>
            ObstacleBehaviour.OnDeath -= IncrementSpeed;
    }
}
