using UnityEngine;

public class BattleScreen : MonoBehaviour, IUiScreen {

    public HPWidget hpWidget;
    public CountdownWidget countdownWidget;

 
    public void Init() {
        GameManager.instance.OnGameStart.AddListener(Init);
        hpWidget.Init();
        countdownWidget.StartCountdown();
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        countdownWidget.StopCounting();
        gameObject.SetActive(false);
    }
}
