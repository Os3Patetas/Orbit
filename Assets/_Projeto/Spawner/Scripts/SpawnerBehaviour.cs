using UnityEngine;
using com.Icypeak.Orbit.Player;
using com.Icypeak.Orbit.Obstacle;

namespace com.Icypeak.Orbit.Spawner
{
    public class SpawnerBehaviour : MonoBehaviour
    {
        public GameObject[] Obstacles;
        public GameObject[] Bonuses;

        public bool CanSpawn = true;
        float _spawnTimer;
        [SerializeField] float spawnCooldown;
        [SerializeField] float MinSpawnCooldown;
        [SerializeField] float timeToDecrement;

        void Update()
        {
            if (!CanSpawn) return;

            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0)
            {
                Vector3 randomOffset = new Vector3();
                randomOffset.x = Random.Range(-2.1f, 2.1f);
                Instantiate(Obstacles[0], this.transform.position + randomOffset, Quaternion.identity);
                _spawnTimer = spawnCooldown;
            }
        }

        public void OnEnable() =>
            ObstacleBehaviour.OnDeath += ReduceSpawnCooldown;

        public void OnDisable() =>
            ObstacleBehaviour.OnDeath -= ReduceSpawnCooldown;

        void ReduceSpawnCooldown()
        {
            spawnCooldown = Mathf.Clamp(spawnCooldown - timeToDecrement, 0.5f, 1.5f);
        }

        public void DisableSpawn()
        {
            CanSpawn = false;
        }

        public void EnableSpawn()
        {
            CanSpawn = true;
        }
    }
}
