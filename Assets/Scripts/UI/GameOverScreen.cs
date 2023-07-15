using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour, IUiScreen
{
    public TextMeshProUGUI seconds;
    public TextMeshProUGUI enemies;

    public void Show() {
        gameObject.SetActive(true);
        seconds.text = StatisticsManager.instance.timePlayed.ToString();
        enemies.text = StatisticsManager.instance.enemiesKilled.ToString();
    }

    public void Hide() => gameObject.SetActive(false);
}
