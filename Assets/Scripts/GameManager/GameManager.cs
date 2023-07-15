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
            MainMenu();
        }

        /// <summary>
        /// Prepare the Canvas for the MainMenu and stops the game
        /// </summary>
        public void MainMenu() {
            UIManager.instance.MainMenu();
            TimeManager.instance.StopPlayTime();
        }
               
        /// <summary>
        /// Prepare the Canvas and start the game
        /// </summary>
        public void Play() {
            UIManager.instance.PlayMenu();
            OnGameStart?.Invoke();
            UIManager.instance.BattleScreenPanel.Init();
        }

        /// <summary>
        /// Prepare the Canvas and restore the game
        /// </summary>
        public void Restore() {
            UIManager.instance.PlayMenu();
            TimeManager.instance.RestorePlayTime();
        }

        /// <summary>
        /// Prepare the Canvas and stops the game and open the LevelUp Screen
        /// </summary>
        public void LevelUpTime() {
            TimeManager.instance.StopPlayTime();
            UIManager.instance.LevelUpMenu();
        }

        /// <summary>
        /// Prepare the Canvas and open the win screen
        /// </summary>
        public void WinGame() {
            TimeManager.instance.StopPlayTime();
            OnGameOver?.Invoke();
            UIManager.instance.GameOverMenu();
        }


        /// <summary>
        /// Prepare the Canvas and open the Game Over screen
        /// </summary>
        public void GameOver() {
            TimeManager.instance.StopPlayTime();
            OnGameOver?.Invoke();
            UIManager.instance.GameOverMenu();
        }
    }
}
