using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New PowerUpBasic", menuName = "bw_test/PowerUps/Basic")]
public class PowerUpBasic : ScriptableObject, IPowerUp {
    [SerializeField] private Stats stats;

    [SerializeField] private Sprite sprite;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private bool isReutilizable;

    public Sprite Image { get => sprite; set => sprite = value; }
    public string Title { get => title; set => title = value; }
    public string Description { get => description; set => description = value; }

    public bool IsReutilizable => isReutilizable;

    public Stats Stats { get => stats; set => stats = value; }

    public void Init() {
       
    }

    public Stats ApplyToStat(Stats statToApply) {
        return statToApply + this.Stats;
    }

}
