using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class CountdownWidget : MonoBehaviour {
    public int maxTime = 60;
    Countdown countdown;
    public UnityEvent<float> OnCountDownStops = new();

    public TextMeshProUGUI counter;

    public void StartCountdown() {
        Debug.Log("AYUDAAAAAA");
        countdown = new Countdown(maxTime);
        countdown.OnTimeOut = (TimeOut);
        countdown.OnTimeUpdate = (TimeUpdate);
        StartCoroutine(countdown.StartCountdown());
    }

    public void TimeUpdate(float time) {
        counter.text = ((int)time).ToString();
    }
    public void TimeOut() {
        OnCountDownStops?.Invoke(countdown.GetRemainingTime());
        GameManager.instance.WinGame();
    }
    public void StopCounting() {
        if (countdown != null) {
            if (countdown.IsCountingDown()) {
                countdown.StopCountdown();
            }
            OnCountDownStops?.Invoke(countdown.GetRemainingTime());

        }
    }
}
