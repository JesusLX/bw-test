using bw_test.Characters;
using bw_test.PowerUps;
using UnityEngine;

namespace bw_test.Controllers {
    public class PowerUpController : MonoBehaviour {
        ICharacter character;

        private void Start() {
            character = GetComponent<ICharacter>();
        }
        public void AddPowerUp(IPowerUp powerUp) {
            character.UpdateStats(powerUp.Stats);

        }
    } 
}
