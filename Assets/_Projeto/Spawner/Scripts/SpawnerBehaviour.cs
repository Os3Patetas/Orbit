using UnityEngine;
using com.Icypeak.Orbit.Player;
using com.Icypeak.Orbit.Obstacle;
using com.Icypeak.Orbit.Utils;

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

        [SerializeField] RandomTimer ObstacleSpawnTimer;
        [SerializeField] RandomTimer BonusSpawnTimer;

        void Awake()
        {
            ObstacleSpawnTimer = new RandomTimer(spawnCooldown, spawnCooldown);
            BonusSpawnTimer = new RandomTimer(10, 20);
        }

        void Update()
        {
            if (!CanSpawn) return;

            ObstacleSpawnTimer.Run(Time.deltaTime);
            if (ObstacleSpawnTimer.TimeHasElapsed)
            {
                SpawnRandomObject(Obstacles);
                ObstacleSpawnTimer.Reset();
            }

            BonusSpawnTimer.Run(Time.deltaTime);
            if (BonusSpawnTimer.TimeHasElapsed)
            {
                SpawnRandomObject(Bonuses);
                BonusSpawnTimer.Reset();
            }
        }

        void OnEnable()
        {
            PlayerStats.OnDeath += DisableSpawn;
            ObstacleBehaviour.OnDeath += ReduceSpawnCooldown;
        }
        void OnDisable()
        {
            PlayerStats.OnDeath -= DisableSpawn;
            ObstacleBehaviour.OnDeath -= ReduceSpawnCooldown;
        }

        private void SpawnRandomObject(GameObject[] obj)
        {
            Vector3 randomOffset = new Vector3();
            randomOffset.x = Random.Range(-2.1f, 2.1f);

            var randomObject = Random.Range(0, obj.Length);

            Instantiate(obj[randomObject], this.transform.position + randomOffset, Quaternion.identity);
        }

        private void ReduceSpawnCooldown()
        {
            spawnCooldown = Mathf.Clamp(spawnCooldown - timeToDecrement, 0.5f, 1.5f);
            ObstacleSpawnTimer.Redefine(spawnCooldown, spawnCooldown);
        }

        public void DisableSpawn() => CanSpawn = false;
        public void EnableSpawn() => CanSpawn = true;
    }
}
