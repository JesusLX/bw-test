using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New PowerUpBasic", menuName = "bw_test/PowerUps/Basic")]
public class PowerUpBasic : ScriptableObject, IPowerUp {
    public Stats stat;

    public Sprite sprite;
    public string description;
    public bool isReutilizable;

    public Sprite Image { get => sprite; set => sprite = value; }
    public string Description { get => description; set => description = value; }

    public bool IsReutilizable => isReutilizable;

    public void Init() {
       
    }

    public Stats ApplyToStat(Stats statToApply) {
        return statToApply + this.stat;
    }

}
