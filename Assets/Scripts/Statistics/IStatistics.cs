namespace bw_test.Managers {
    internal interface IStatistics {
        int EnemiesKilled { get; set; }
        int PlayerKilled { get; set; }
        int PlayerWins { get; set; }
        int TimePlayed { get; set; }

        void Init();
        void OnEnemyKilled();
        void OnPlayerKilled();
        void OnPlayerWins();
        void SetTimePlayed(float timePlayed);
        void WatchTime();
    }
}