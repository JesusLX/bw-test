using bw_test.Characters;
using bw_test.Managers;
using bw_test.ST;
using UnityEngine;
using UnityEngine.UI;

namespace bw_test.UIScreen.UIWidgets {
    public class ExpWidget : MonoBehaviour, IWidget {
        public Slider expSlider;

        private void Start() {
            FindObjectOfType<Player>().OnExperienceChanged.AddListener(UpdateExperience);
            FindObjectOfType<LevelManager>().OnLevelUp.AddListener(UpdateExperience);
        }

        /// <summary>
        /// Uptade the slider with the level stats
        /// </summary>
        /// <param name="levelST">Level stats to get the values</param>
        public void UpdateExperience(Stats.LevelST levelST) {
            float exp = 0;
            if (levelST.Experience != 0) {
                exp = levelST.Experience / FindObjectOfType<LevelManager>().ExpNeeded;
            }
            expSlider.value = exp;
        }

        #region IWidget
        public void Init() {
            expSlider.value = 0;
        }

        public void Show() {
        }

        public void Hide() {
        }
        #endregion
    }
}
