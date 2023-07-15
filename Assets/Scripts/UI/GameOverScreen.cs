using bw_test.Managers;
using TMPro;
using UnityEngine;

namespace bw_test.UIScreen {
    public class GameOverScreen : MonoBehaviour, IUiScreen {
        public TextMeshProUGUI seconds;
        public TextMeshProUGUI enemies;

        public void Show() {
            gameObject.SetActive(true);
            seconds.text = StatisticsManager.instance.TimePlayed.ToString();
            enemies.text = StatisticsManager.instance.EnemiesKilled.ToString();
        }

        public void Hide() => gameObject.SetActive(false);
    }

}