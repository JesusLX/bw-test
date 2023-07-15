using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager> {

    public UnityEvent OnGameStart = new();
    public UnityEvent OnGameOver = new();
    private void Start() {
        UIManager.instance.Hide(UIManager.instance.GameOverPanel);
        UIManager.instance.Show(UIManager.instance.MainMenuPanel);
        UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
        UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
    }
    public void Play() {
        Debug.LogWarning("AUIIIIIIIIIIIIII");
        UIManager.instance.Hide(UIManager.instance.GameOverPanel);
        UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
        UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
        UIManager.instance.Show(UIManager.instance.BattleScreenPanel);
        Invokethis();
        UIManager.instance.BattleScreenPanel.Init();
    }

    [ContextMenu("Test/Init")]
    public void Invokethis() {
        OnGameStart?.Invoke();

    }
    public void GameOver() {
        TimeManager.instance.StopPlayTime();
        OnGameOver?.Invoke();
        UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
        UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
        UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
        UIManager.instance.Show(UIManager.instance.GameOverPanel);
    }

    public void Restore() {
        UIManager.instance.Hide(UIManager.instance.GameOverPanel);
        UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
        UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
        UIManager.instance.Show(UIManager.instance.BattleScreenPanel);
        TimeManager.instance.RestorePlayTime();
    }

    public void WinGame() {
        TimeManager.instance.StopPlayTime();
        OnGameOver?.Invoke();
        UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
        UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
        UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
        UIManager.instance.Show(UIManager.instance.GameOverPanel);
    }
    public void LevelUpTime() {
        TimeManager.instance.StopPlayTime();
        UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
        UIManager.instance.Show(UIManager.instance.LevelUpPanel);
        UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
        UIManager.instance.Hide(UIManager.instance.GameOverPanel);
    }
}
