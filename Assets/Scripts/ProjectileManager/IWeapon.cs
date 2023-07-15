using bw_test.Characters;

namespace bw_test.Weapons {
    public interface IWeapon {
        void Init(ICharacter player);
        void TryAttack();
        void UpdateCanAttack(bool can);
    }
}