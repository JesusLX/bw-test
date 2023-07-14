using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    private Player player;
    private float expNeeded = 10;
    private float levelUpMultiplier = 1.2f;
    public UnityEvent<int> OnLevelUp;

    private void Start() {
        player = FindObjectOfType<Player>();
        player.OnExperienceChanged.AddListener(WatchExperiende);
    }
    public void WatchExperiende(Stats.LevelST level) {
        if(level.Experience >= expNeeded) {
            expNeeded += expNeeded * levelUpMultiplier;
            level.Level++;
            UIManager.instance.Show(UIManager.instance.LevelUpPanel);
            OnLevelUp?.Invoke(level.Level);
            //WatchExperiende(level);
        }
    }

}
