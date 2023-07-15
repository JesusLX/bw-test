using bw_test.Managers;
using bw_test.UIScreen.UIWidgets;
using System.Collections.Generic;
using UnityEngine;

namespace bw_test.UIScreen {
    public class BattleScreen : MonoBehaviour, IUiScreen {

        List<IWidget> widgets = new();

        private void Start() {
        }

        public void Init() {

            GameManager.instance.OnGameStart.AddListener(Init);
            GetWidgets();

            widgets.ForEach(x => {
                x.Init();
                });
        }

        public void GetWidgets() {
            widgets = new List<IWidget>(GetComponentsInChildren<IWidget>());
        }

        public void Show() {

            gameObject.SetActive(true);
            widgets.ForEach(x => x.Show());
        }

        public void Hide() {

            widgets.ForEach(x => x.Hide());
            gameObject.SetActive(false);
        }
    }
}
