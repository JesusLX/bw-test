using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : Singleton<StatisticsManager> {

    public int enemiesKilled;
    public int playerKilled;
    public int playerWins;
    public int timePlayed;

    private void Start() {
        Player player = FindObjectOfType<Player>();
        player.OnEnemyKilled.AddListener(OnEnemyKilled);
        player.OnDie.AddListener(OnPlayerKilled);
        FindObjectOfType<CountdownWidget>().OnCountDownStops.AddListener(SetTimePlayed);

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

    public void SetTimePlayed(float timePlayed) {
        this.timePlayed = (int)timePlayed;
    }
}
