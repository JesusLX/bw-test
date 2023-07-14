using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : Singleton<TimeManager> {
    public UnityEvent OnPlayTimeStart;
    public UnityEvent OnPlayTimeStop;
    public UnityEvent OnPlayTimeRestore;

    private void Start() {
 
    }
    public void StartPlayTime() {
        OnPlayTimeStart?.Invoke();
    }

    public void StopPlayTime() {
        OnPlayTimeStop?.Invoke();
    }

    public void RestorePlayTime() {
        OnPlayTimeRestore?.Invoke();
    }

}
