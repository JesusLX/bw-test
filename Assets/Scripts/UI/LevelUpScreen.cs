using bw_test.Managers;
using UnityEngine;

namespace bw_test.UIScreen {
    public class LevelUpScreen : MonoBehaviour, IUiScreen {
        PowerUpsManager levelManager;
        private void Awake() {
            levelManager = FindObjectOfType<PowerUpsManager>();
        }

        #region IUiScreen
        public void Show() {
            gameObject.SetActive(true);
            TimeManager.instance.StopPlayTime();
            levelManager.LetsSelect();
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
        #endregion
    } 
}
