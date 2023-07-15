using bw_test.Characters;
using bw_test.UIScreen.UIWidgets;

namespace bw_test.Managers {
    public class StatisticsManager : Singleton<StatisticsManager> {

        public int enemiesKilled;
        public int playerKilled;
        public int playerWins;
        public int timePlayed;

        private void Start() {
            Player player = FindObjectOfType<Player>();
            player.OnEnemyKilled.AddListener(OnEnemyKilled);
            player.OnDie.AddListener(OnPlayerKilled);
            GameManager.instance.OnGameStart.AddListener(Init);
            GameManager.instance.OnGameOver.AddListener(WatchTime);

        }

        public void Init() {
            enemiesKilled = 0;
            playerKilled = 0;
        }
        public void OnPlayerKilled() {
            playerKilled++;
        }

        public void OnEnemyKilled() {
            enemiesKilled++;
        }

        public void OnPlayerWins() {
            playerWins++;
        }

        /// <summary>
        /// Check CountdowWidget and get the current time of the countdown
        /// </summary>
        public void WatchTime() {
            SetTimePlayed(CountdownWidget.instance.CurrentTime);
        }
        public void SetTimePlayed(float timePlayed) {
            this.timePlayed = (int)timePlayed;
        }
    } 
}