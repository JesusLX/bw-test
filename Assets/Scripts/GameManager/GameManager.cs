using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Start() {
        TimeManager.instance.StopPlayTime();
    }
    public void Play() {
        UIManager.instance.Hide(UIManager.instance.GameOverPanel);
        UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
        UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
        UIManager.instance.Show(UIManager.instance.BattleScreenPanel);
        TimeManager.instance.StartPlayTime();
    }
}
