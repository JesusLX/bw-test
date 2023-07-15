using bw_test.Characters;
using bw_test.ST;

namespace bw_test.Movement {
    internal interface IMovement {
        void Init(ICharacter player);
        void UpdateCanMove(bool can);
        void UpdateStats(Stats stats);
        void TryMove();
    } 
}