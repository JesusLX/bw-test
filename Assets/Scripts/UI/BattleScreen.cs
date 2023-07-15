using UnityEngine;

public class BattleScreen : MonoBehaviour, IUiScreen {

    public HPWidget hpWidget;
    public CountdownWidget countdownWidget;
    public ExpWidget expWidget;


    public void Init() {
        GameManager.instance.OnGameStart.AddListener(Init);
        hpWidget.Init();
        countdownWidget.StartCountdown();
        expWidget.Init();
    }

    public void Show() {
        gameObject.SetActive(true);
        countdownWidget.RestoreCountdown();
    }

    public void Hide() {
        countdownWidget.StopCounting();
        gameObject.SetActive(false);
    }
}
