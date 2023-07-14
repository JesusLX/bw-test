using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : Singleton<TimeManager> {
    public UnityEvent OnPlayTimeStart;
    public UnityEvent OnPlayTimeStop;
    public UnityEvent OnPlayTimeRestore;

    private void Start() {
        GameManager.instance.OnGameStart.AddListener(StartPlayTime);
    }
    public void StartPlayTime() {
        Debug.Log("Empieza el tiempo");
        OnPlayTimeStart?.Invoke();
    }

    public void StopPlayTime() {
        Debug.Log("Para el tiempo");
        OnPlayTimeStop?.Invoke();
    }

    public void RestorePlayTime() {
        Debug.Log("Restaura el tiempo");
        OnPlayTimeRestore?.Invoke();
    }

}
