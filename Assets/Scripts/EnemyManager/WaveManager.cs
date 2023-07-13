using bw_test.EnemyPool;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveManager : MonoBehaviour, ITimeAffected
{
    public Vector2 rajdomTimeBtSpawns;
    public Vector3 spawnZoneStart;
    public Vector3 spawnZoneEnd;
    Countdown spawnCountdown;
    bool spawning;

    private void Start() {
    }

    [ContextMenu("Test/Init")]
    public void Init() {
        Spawn();
        StartCountdown();
    }

    private void Spawn() {
       var enemy = EnemyManager.instance.PlayRandom(this.transform,new Vector3(Random.Range(spawnZoneStart.x, spawnZoneEnd.x), Random.Range(spawnZoneStart.y, spawnZoneEnd.y), Random.Range(spawnZoneStart.z, spawnZoneEnd.z)), Quaternion.identity);
    }

    public void TimeOut() {
        Spawn();
        StartCountdown();
    }

    public void StartCountdown() {
        spawnCountdown = new Countdown(Random.Range(rajdomTimeBtSpawns.x, rajdomTimeBtSpawns.y));
        spawnCountdown.OnTimeOut = (TimeOut);
        StartCoroutine(spawnCountdown.StartCountdown());
    }

    #region ITimeAffected
    public void TimeStops() {
        spawnCountdown.StopCountdown();
    }
    public void TimeReanude() {
        if(spawning) {
            StartCoroutine(spawnCountdown.StartCountdown());
        }
    }
    #endregion
}
