using bw_test.Characters;
using bw_test.ST;
using UnityEngine;
using UnityEngine.Events;

namespace bw_test.Managers {
    public class LevelManager : MonoBehaviour {
        private Player player;
        private float expNeededBase = 10;
        private float expNeeded = 10;
        private float levelUpMultiplier = 1.2f;
        public UnityEvent<Stats.LevelST> OnLevelUp;

        public float ExpNeeded { get => expNeeded; set => expNeeded = value; }

        private void Start() {
            player = FindObjectOfType<Player>();
            player.OnExperienceChanged.AddListener(WatchExperiende);
            GameManager.instance.OnGameStart.AddListener(Init);
        }
        
        public void Init() {
            ExpNeeded = expNeededBase;
        }

        /// <summary>
        /// Check if the level experience is enough to level up and does it
        /// </summary>
        /// <param name="level"></param>
        public void WatchExperiende(Stats.LevelST level) {

            if (level.Experience >= ExpNeeded) {
                ExpNeeded += ExpNeeded * levelUpMultiplier;
                level.Level++;
                GameManager.instance.LevelUpTime();
                OnLevelUp?.Invoke(level);
            }
        }

    }

}