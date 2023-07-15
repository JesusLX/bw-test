using bw_test.Characters;
using bw_test.UIScreen.UIWidgets;

namespace bw_test.Managers {
    public class StatisticsManager : Singleton<StatisticsManager>, IStatistics {

        private int enemiesKilled;
        private int playerKilled;
        private int playerWins;
        private int timePlayed;

        public int EnemiesKilled { get => enemiesKilled; set => enemiesKilled = value; }
        public int PlayerKilled { get => playerKilled; set => playerKilled = value; }
        public int PlayerWins { get => playerWins; set => playerWins = value; }
        public int TimePlayed { get => timePlayed; set => timePlayed = value; }

        private void Start() {
            Player player = FindObjectOfType<Player>();
            player.OnEnemyKilled.AddListener(OnEnemyKilled);
            player.OnDie.AddListener(OnPlayerKilled);
            GameManager.instance.OnGameStart.AddListener(Init);
            GameManager.instance.OnGameOver.AddListener(WatchTime);

        }

        public void Init() {
            EnemiesKilled = 0;
            PlayerKilled = 0;
        }
        public void OnPlayerKilled() {
            PlayerKilled++;
        }

        public void OnEnemyKilled() {
            EnemiesKilled++;
        }

        public void OnPlayerWins() {
            PlayerWins++;
        }

        /// <summary>
        /// Check CountdowWidget and get the current time of the countdown
        /// </summary>
        public void WatchTime() {
            SetTimePlayed(CountdownWidget.instance.GetTimePlayed());
        }
        public void SetTimePlayed(float timePlayed) {
            this.TimePlayed = (int)timePlayed;
        }
    } 
}