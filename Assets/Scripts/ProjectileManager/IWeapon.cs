public interface IWeapon {
    void Init(ICharacter player);
    void TryAttack();
    void UpdateCanAttack(bool can);
}