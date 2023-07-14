using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
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
