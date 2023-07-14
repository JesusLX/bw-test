using bw_test.EnemyPool;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveManager : MonoBehaviour, ITimeAffected
{
    public Vector2 initRandomTimeBtSpawns;
    private Vector2 randomTimeBtSpawns;
    public Vector3 spawnZoneStart;
    public Vector3 spawnZoneEnd;
    Countdown spawnCountdown;
    bool spawning;

    private void Start() {
    }
    private void OnEnable() {
        FindObjectOfType<LevelManager>().OnLevelUp.AddListener(LevelUp);
        AttachTimeEvents();
    }
    private void OnDisable() {
        FindObjectOfType<LevelManager>().OnLevelUp.RemoveListener(LevelUp);
        DetachTimeEvents();
    }
    [ContextMenu("Test/Init")]
    public void Init() {
        randomTimeBtSpawns = initRandomTimeBtSpawns;
        spawning = true;
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
        spawnCountdown = new Countdown(Random.Range(randomTimeBtSpawns.x, randomTimeBtSpawns.y));
        spawnCountdown.OnTimeOut = (TimeOut);
        StartCoroutine(spawnCountdown.StartCountdown());
    }

    public void LevelUp(int level) {
        randomTimeBtSpawns.y -= 0.2f;
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
        if(spawnCountdown != null) {
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
