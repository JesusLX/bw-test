using UnityEngine;
using UnityEngine.Events;

namespace bw_test.Managers {
    public class TimeManager : Singleton<TimeManager> {
        public UnityEvent OnPlayTimeStart;
        public UnityEvent OnPlayTimeStop;
        public UnityEvent OnPlayTimeRestore;

        private void Start() {
            GameManager.instance.OnGameStart.AddListener(StartPlayTime);
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
}
