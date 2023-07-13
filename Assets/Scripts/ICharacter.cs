using UnityEngine.Events;

public interface ICharacter {
    public Stats Stats { get; set; }
    public UnityEvent<Stats> OnStatsChanged { get; }

    public void AddWeapon(IWeapon weapon);
}