using bw_test.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace bw_test.UIScreen {
    public class MainMenu : MonoBehaviour, IUiScreen {

        public Button playButton;

        private void Awake() {
            playButton.onClick.AddListener(Play);
        }

        public void Play() {
            GameManager.instance.Play();
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }

}