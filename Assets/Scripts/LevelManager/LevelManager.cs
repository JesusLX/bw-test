using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour {
    private Player player;
    private float expNeededBase = 10;
    private float expNeeded = 10;
    private float levelUpMultiplier = 1.2f;
    public UnityEvent<int> OnLevelUp;

    public float ExpNeeded { get => expNeeded; set => expNeeded = value; }

    private void Start() {
        player = FindObjectOfType<Player>();
        player.OnExperienceChanged.AddListener(WatchExperiende);
        GameManager.instance.OnGameStart.AddListener(Init);
    }
    public void Init() {
        ExpNeeded = expNeededBase;
    }
    public void WatchExperiende(Stats.LevelST level) {
        Debug.Log("Needed Exp " + ExpNeeded);

        if (level.Experience >= ExpNeeded) {
            ExpNeeded += ExpNeeded * levelUpMultiplier;
            level.Level++;
            GameManager.instance.LevelUpTime();
            OnLevelUp?.Invoke(level.Level);
            //WatchExperiende(level);
        }
    }

}
