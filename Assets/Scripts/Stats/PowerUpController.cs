using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    ICharacter character;

    private void Start() {
        character = GetComponent<ICharacter>();
    }
    public void AddPowerUp(IPowerUp powerUp) {
        character.UpdateStats(powerUp.Stats);

    }
}
