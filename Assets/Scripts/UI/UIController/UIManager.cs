using bw_test.UIScreen;

namespace bw_test.Managers {
    public class UIManager : Singleton<UIManager> {
        public LevelUpScreen LevelUpPanel;
        public MainMenu MainMenuPanel;
        public GameOverScreen GameOverPanel;
        public BattleScreen BattleScreenPanel;

        public void Show(IUiScreen screen) {
            screen.Show();
        }
        public void Hide(IUiScreen screen) {
            screen.Hide();
        }

        public void MainMenu() {
            UIManager.instance.Hide(UIManager.instance.GameOverPanel);
            UIManager.instance.Show(UIManager.instance.MainMenuPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
        }

        /// <summary>
        /// Prepare the Canvas for the game
        /// </summary>
        public void PlayMenu() {
            UIManager.instance.Hide(UIManager.instance.GameOverPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Show(UIManager.instance.BattleScreenPanel);
        }

        /// <summary>
        /// Prepare the Canvas and open the LevelUp Screen
        /// </summary>
        public void LevelUpMenu() {
            TimeManager.instance.StopPlayTime();
            UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
            UIManager.instance.Show(UIManager.instance.LevelUpPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Hide(UIManager.instance.GameOverPanel);
        }


        /// <summary>
        /// Prepare the Canvas and open the Game Over screen
        /// </summary>
        public void GameOverMenu() {

            UIManager.instance.Hide(UIManager.instance.BattleScreenPanel);
            UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
            UIManager.instance.Hide(UIManager.instance.MainMenuPanel);
            UIManager.instance.Show(UIManager.instance.GameOverPanel);
        }
    } 
}
