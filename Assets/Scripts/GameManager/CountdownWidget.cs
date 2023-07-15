using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class CountdownWidget : Singleton<CountdownWidget> {
    public int maxTime = 60;
    private int currentTime = 60;
    Countdown countdown;
    Coroutine coroutineCD;
    public UnityEvent<float> OnCountDownStops = new();

    public TextMeshProUGUI counter;

    public int CurrentTime { get => currentTime; set => currentTime = value; }

    public void StartCountdown() {
        CurrentTime = maxTime;
        countdown = new Countdown(maxTime);
        countdown.OnTimeOut = (TimeOut);
        countdown.OnTimeUpdate = (TimeUpdate);
        if(coroutineCD != null) {
            StopCoroutine(coroutineCD);
        }
        coroutineCD = StartCoroutine(countdown.StartCountdown());
    }

    public void TimeUpdate(float time) {
        CurrentTime = (int)time;
        counter.text = (CurrentTime).ToString();
    }
    public void TimeOut() {
        OnCountDownStops?.Invoke(countdown.GetRemainingTime());
        GameManager.instance.WinGame();
    }
    public void RestoreCountdown() {
        Debug.Log("Contador " + countdown);
        if (countdown != null) {
            coroutineCD = StartCoroutine(countdown.StartCountdown());

        }
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
