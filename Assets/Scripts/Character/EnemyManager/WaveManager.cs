using bw_test.Characters;
using bw_test.EnemyPool;
using bw_test.ST;
using System.Collections.Generic;
using UnityEngine;

namespace bw_test.Managers {
    public class WaveManager : MonoBehaviour, ITimeAffected {
        public Vector2 initRandomTimeBtSpawns;
        private Vector2 randomTimeBtSpawns;
        public Vector3 spawnZoneStart;
        public Vector3 spawnZoneEnd;
        Countdown spawnCountdown;
        bool spawning;

        private void Start() {
        }
        private void OnEnable() {
            FindObjectOfType<LevelManager>().OnLevelUp.AddListener(IncreaseDifficulty);
            AttachTimeEvents();
        }
        private void OnDisable() {
            var levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null) {
                levelManager.OnLevelUp.RemoveListener(IncreaseDifficulty);
            }
            DetachTimeEvents();
        }
        [ContextMenu("Test/Init")]
        public void Init() {
            new List<Enemy>(FindObjectsOfType<Enemy>()).ForEach(e => e.Kill());
            randomTimeBtSpawns = initRandomTimeBtSpawns;
            spawning = true;
            Spawn();
            StartCountdown();
        }

        /// <summary>
        /// Spawn a random enemy in a random position of the spawn area
        /// </summary>
        private void Spawn() {
            var enemy = EnemyManager.instance.PlayRandom(this.transform, new Vector3(Random.Range(spawnZoneStart.x, spawnZoneEnd.x), Random.Range(spawnZoneStart.y, spawnZoneEnd.y), Random.Range(spawnZoneStart.z, spawnZoneEnd.z)), Quaternion.identity);
        }

        /// <summary>
        /// End of countdown, time to spawn and start another countdown
        /// </summary>
        public void TimeOut() {
            Spawn();
            StartCountdown();
        }

        /// <summary>
        /// Init te spawn countdown
        /// </summary>
        public void StartCountdown() {
            spawnCountdown = new Countdown(Random.Range(randomTimeBtSpawns.x, randomTimeBtSpawns.y));
            spawnCountdown.OnTimeOut = (TimeOut);
            StartCoroutine(spawnCountdown.StartCountdown());
        }

        /// <summary>
        /// Increments the difficulty decreasing the time between spawns
        /// </summary>
        /// <param name="level"></param>
        public void IncreaseDifficulty(Stats.LevelST level) {
            randomTimeBtSpawns.y -= 0.3f;
        }

        #region ITimeAffected
        public void OnPlayTimeStarts() {
            Init();
        }

        public void OnPlayTimeRestore() {
            if (spawning) {
                StartCoroutine(spawnCountdown.StartCountdown());
            }
        }

        public void OnPlayTimeStops() {
            if (spawnCountdown != null) {
                spawnCountdown.StopCountdown();
            }
        }

        public void AttachTimeEvents() {
            TimeManager.instance.OnPlayTimeStart.AddListener(OnPlayTimeStarts);
            TimeManager.instance.OnPlayTimeStop.AddListener(OnPlayTimeStops);
            TimeManager.instance.OnPlayTimeRestore.AddListener(OnPlayTimeRestore);
        }

        public void DetachTimeEvents() {
            TimeManager.instance.OnPlayTimeStart.RemoveListener(OnPlayTimeStarts);
            TimeManager.instance.OnPlayTimeStop.RemoveListener(OnPlayTimeStops);
            TimeManager.instance.OnPlayTimeRestore.RemoveListener(OnPlayTimeRestore);
        }

        #endregion
    } 
}
