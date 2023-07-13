using TMPro;
using UnityEngine;

public interface IPowerUp {

    public Sprite Image { get; set; }
    public string Description { get; set; }
    bool IsReutilizable { get; }

    public Stats ApplyToStat(Stats statToApply);
    void Init();
}