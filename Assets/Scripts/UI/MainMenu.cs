using UnityEngine;

public class MainMenu : MonoBehaviour, IUiScreen {


    public void Play() {
        Hide();
        GameManager.instance.Play();
    }

    public void Show() {
        TimeManager.instance.StopPlayTime();
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
