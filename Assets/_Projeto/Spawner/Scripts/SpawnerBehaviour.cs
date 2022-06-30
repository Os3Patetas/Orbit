using UnityEngine;
using com.Icypeak.Orbit.Manager;

namespace com.Icypeak.Orbit.Spawner
{
    public class SpawnerBehaviour : MonoBehaviour
    {
        public GameObject[] Obstacles;
        public GameObject[] Bonuses;

        public bool CanSpawn = true;
        float _spawnTimer;
        [SerializeField] float bonusSpawnChanceMult = 1f;
        [SerializeField] float obstacleSpawnChanceMult = 1f;
        [SerializeField] float spawnCooldown;

        void Update()
        {
            if (!CanSpawn) return;

            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0)
            {
                var bonusOdd = Random.Range(1, 100) * bonusSpawnChanceMult;
                var obstacleOdd = Random.Range(1, 100) * obstacleSpawnChanceMult;
                var randomSpawnPos = this.transform.position + new Vector3(Random.Range(-2.1f,2.1f),0,0);
                if(obstacleOdd > bonusOdd)
                {
                    int randomEl = Random.Range(0, Obstacles.Length);
                    Instantiate(Obstacles[randomEl], randomSpawnPos, Quaternion.identity);
                }
                else
                {
                    int randomEl = Random.Range(0, Bonuses.Length);
                    Instantiate(Bonuses[randomEl], randomSpawnPos, Quaternion.identity);
                }

                _spawnTimer = spawnCooldown;
            }
        }

        public void DisableSpawn() =>
            CanSpawn = false;

        public void EnableSpawn() =>
            CanSpawn = true;

        private void OnEnable()
        {
            DifficultyManager.Instance.OnDifficultyChange += UpdateSpawnCooldown;
        }
        private void OnDisable()
        {
            DifficultyManager.Instance.OnDifficultyChange -= UpdateSpawnCooldown;
        }

        void UpdateSpawnCooldown()
        {
            spawnCooldown = DifficultyManager.Instance.TargetSpawnCooldown;
        }
    }
}
