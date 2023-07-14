public interface IWeapon {
    void Init(Player player);
    bool TryAttack();
    void UpdateCanAttack(bool can);
}