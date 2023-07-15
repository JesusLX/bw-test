using UnityEngine;
using bw_test.ST;
namespace bw_test.PowerUps {
    public interface IPowerUp {

        public string Title { get; set; }
        public Sprite Image { get; set; }
        public string Description { get; set; }
        public Stats Stats { get; set; }
        bool IsReutilizable { get; }

        public Stats ApplyToStat(Stats statToApply);
        void Init();
    } 
}