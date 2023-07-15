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
    } 
}
