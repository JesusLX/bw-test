using bw_test.Characters;
using bw_test.Managers;
using bw_test.ST;
using UnityEngine;

namespace bw_test.Movement {
    public class Movement : MonoBehaviour, IMovement, ITimeAffected {

        [SerializeField] internal Stats.MovementST stats;
        [SerializeField] internal bool canMove = false;

        private void OnEnable() {
            OnEnableEvents();
        }
        private void OnDisable() {
            OnDisableEvents();
        }

        internal virtual void OnEnableEvents() {
            AttachTimeEvents();
        }

        internal virtual void OnDisableEvents() {
            DetachTimeEvents();
        }

        #region IMovement
        virtual public void Init(ICharacter player) { }


        virtual public void UpdateCanMove(bool can) {
            canMove = can;
        }

        virtual public void UpdateStats(Stats stats) {
            this.stats = stats.Movement;
        }

        virtual public void TryMove() { }
        #endregion


        #region ITimeAffected
        public void OnPlayTimeStarts() {
            UpdateCanMove(true);
        }

        public void OnPlayTimeRestore() {
            UpdateCanMove(true);
        }

        public void OnPlayTimeStops() {
            UpdateCanMove(false);
        }

        public void AttachTimeEvents() {
            TimeManager.instance.OnPlayTimeStart.AddListener(OnPlayTimeStarts);
            TimeManager.instance.OnPlayTimeStop.AddListener(OnPlayTimeStops);
            TimeManager.instance.OnPlayTimeRestore.AddListener(OnPlayTimeRestore);
        }

        public void DetachTimeEvents() {
            TimeManager.instance.OnPlayTimeStart.RemoveListener(OnPlayTimeStarts);
            TimeManager.instance.OnPlayTimeStop.RemoveListener(OnPlayTimeStops);
            TimeManager.instance.OnPlayTimeRestore.RemoveListener(OnPlayTimeRestore);
        }

        #endregion
    }

}