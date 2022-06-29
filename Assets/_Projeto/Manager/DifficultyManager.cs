using System;
using UnityEngine;

using com.Icypeak.Orbit.Obstacle;

namespace com.Icypeak.Orbit.Manager
{
    public class DifficultyManager : MonoBehaviour
    {
        public static DifficultyManager Instance;

        public float ObstacleTargetSpeed;
        public float TargetSpawnCooldown;
        [SerializeField] float ObstacleInitialSpeed;
        [SerializeField] float ObstacleInitialSpawnSpeed;
        [SerializeField] float ObstacleSpeedToAdd;
        [SerializeField] float ObstacleMaxSpeed;

        public Action OnDifficultyChange;

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
            TargetSpawnCooldown = ObstacleInitialSpawnSpeed;
        }

        private void IncrementDifficulty()
        {
            ObstacleTargetSpeed = Mathf.Clamp(ObstacleTargetSpeed + ObstacleSpeedToAdd, 0, ObstacleMaxSpeed);
            TargetSpawnCooldown = ObstacleTargetSpeed * ObstacleInitialSpawnSpeed / ObstacleInitialSpeed;
            OnDifficultyChange?.Invoke();
        }

        private void OnEnable() =>
            ObstacleBehaviour.OnDeath += IncrementDifficulty;
        private void OnDisable() =>
            ObstacleBehaviour.OnDeath -= IncrementDifficulty;
    }
}
