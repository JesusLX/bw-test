using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace bw_test.Managers {
    public class GameManager : Singleton<GameManager> {

        public UnityEvent OnGameStart = new();
        public UnityEvent OnGameOver = new();
        private void Start() {
            UIManager.instance.Hide(UIManager.instance.GameOverPanel);
            UIManager.instance.Show(UIManager.instance.MainMenuPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
        }

        /// <summary>
        /// Prepare the Canvas and start the game
        /// </summary>
        public void Play() {
            UIManager.instance.Hide(UIManager.instance.GameOverPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Show(UIManager.instance.BattleScreenPanel);
            OnGameStart?.Invoke();

            UIManager.instance.BattleScreenPanel.Init();
        }

        /// <summary>
        /// Prepare the Canvas and restore the game
        /// </summary>
        public void Restore() {
            UIManager.instance.Hide(UIManager.instance.GameOverPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Show(UIManager.instance.BattleScreenPanel);
            TimeManager.instance.RestorePlayTime();
        }

        /// <summary>
        /// Prepare the Canvas and stops the game and open the LevelUp Screen
        /// </summary>
        public void LevelUpTime() {
            TimeManager.instance.StopPlayTime();
            UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
            UIManager.instance.Show(UIManager.instance.LevelUpPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Hide(UIManager.instance.GameOverPanel);
        }

        /// <summary>
        /// Prepare the Canvas and open the win screen
        /// </summary>
        public void WinGame() {
            TimeManager.instance.StopPlayTime();
            OnGameOver?.Invoke();
            UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Show(UIManager.instance.GameOverPanel);
        }


        /// <summary>
        /// Prepare the Canvas and open the Game Over screen
        /// </summary>
        public void GameOver() {
            TimeManager.instance.StopPlayTime();
            OnGameOver?.Invoke();
            UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Show(UIManager.instance.GameOverPanel);
        }
    }
}
