using UnityEngine;

namespace Heroes
{
    public class HeroSettings : MonoBehaviour
    {
        [SerializeField] private Sprite _classIconDamage;
        [SerializeField] private Sprite _classIconDefender;
        [SerializeField] private Sprite _secretClass;
        
        [SerializeField] private float _lowMultiplier = 0.3f;
        [SerializeField] private float _mediumMultiplier = 0.6f;
        [SerializeField] private float _highMultiplier = 1f;
        
        private readonly float _health = 100f;
        private readonly float _attack = 100f;
        private readonly float _defense = 100f;
        private readonly float _speed = 100f;
        
        private enum PriceForHero
        {
            BowHero = 1000,
            MagicWand = 2000,
            DoubleSword = 3000,
            SwordShield = 4000,
            TwoHandsSword = 5000
        }
        
        public Sprite GetClassIcon(string heroName)
        {
            switch (heroName)
            {
                case GlobalConstants.BOW_HERO:
                case GlobalConstants.MAGIC_WAND:
                case GlobalConstants.DOUBLE_SWORD:
                case GlobalConstants.TWO_HANDS_SWORD:
                    return _classIconDamage;
                case  GlobalConstants.NO_WEAPON:
                    case  GlobalConstants.SWORD_SHIELD:
                    return _classIconDefender;
                default:
                    return _secretClass;
            }
        }

        public string GetClassName(string heroName)
        {
            return heroName switch
            {
                GlobalConstants.NO_WEAPON => "No Weapon Hero",
                GlobalConstants.BOW_HERO => "Bow Hero",
                GlobalConstants.MAGIC_WAND => "Magic Wand Hero",
                GlobalConstants.DOUBLE_SWORD => "Double Sword Hero",
                GlobalConstants.SWORD_SHIELD => "Sword Shield Hero",
                GlobalConstants.TWO_HANDS_SWORD => "Two Hands Sword Hero",
                _ => "Secret Hero"
            };
        }

        public float GetHeroSpeed(string heroName)
        {
            return heroName switch
            {
                GlobalConstants.NO_WEAPON => _speed * _lowMultiplier,
                GlobalConstants.BOW_HERO => _speed * _highMultiplier,
                GlobalConstants.MAGIC_WAND => _speed * _lowMultiplier,
                GlobalConstants.DOUBLE_SWORD => _speed * _highMultiplier,
                GlobalConstants.SWORD_SHIELD => _speed * _lowMultiplier,
                GlobalConstants.TWO_HANDS_SWORD => _speed * _highMultiplier,
                _ => 0
            };
        }

        public float GetHeroDefense(string heroName)
        {
            return heroName switch
            {
                GlobalConstants.NO_WEAPON => _defense * _lowMultiplier,
                GlobalConstants.BOW_HERO => _defense * _lowMultiplier,
                GlobalConstants.MAGIC_WAND => _defense * _lowMultiplier,
                GlobalConstants.DOUBLE_SWORD => _defense * _lowMultiplier,
                GlobalConstants.SWORD_SHIELD => _defense * _highMultiplier,
                GlobalConstants.TWO_HANDS_SWORD => _defense * _mediumMultiplier,
                _ => 0
            };
        }

        public float GetHeroAttack(string heroName)
        {
            return heroName switch
            {
                GlobalConstants.NO_WEAPON => _attack * _lowMultiplier,
                GlobalConstants.BOW_HERO => _attack * _highMultiplier,
                GlobalConstants.MAGIC_WAND => _attack * _highMultiplier,
                GlobalConstants.DOUBLE_SWORD => _attack * _mediumMultiplier,
                GlobalConstants.SWORD_SHIELD => _attack * _lowMultiplier,
                GlobalConstants.TWO_HANDS_SWORD => _attack * _highMultiplier,
                _ => 0
            };
        }

        public float GetHeroHealth(string heroName)
        {
            return heroName switch
            {
                GlobalConstants.NO_WEAPON => _health * _lowMultiplier,
                GlobalConstants.BOW_HERO => _health * _lowMultiplier,
                GlobalConstants.MAGIC_WAND => _health * _lowMultiplier,
                GlobalConstants.DOUBLE_SWORD => _health * _mediumMultiplier,
                GlobalConstants.SWORD_SHIELD => _health * _highMultiplier,
                GlobalConstants.TWO_HANDS_SWORD => _health * _mediumMultiplier,
                _ => 0
            };
        }

        public int GetHeroPrice(string heroName)
        {
            return heroName switch
            {
                GlobalConstants.BOW_HERO => (int)PriceForHero.BowHero,
                GlobalConstants.MAGIC_WAND => (int)PriceForHero.MagicWand,
                GlobalConstants.DOUBLE_SWORD => (int)PriceForHero.DoubleSword,
                GlobalConstants.SWORD_SHIELD => (int)PriceForHero.SwordShield,
                GlobalConstants.TWO_HANDS_SWORD => (int)PriceForHero.TwoHandsSword,
                _ => 0
            };
        }

        public string GetPlayerName(string heroName)
        {
            return heroName switch
            {
                GlobalConstants.NO_WEAPON => "NoWeapon01",
                GlobalConstants.BOW_HERO => "Bow01",
                GlobalConstants.MAGIC_WAND => "MagicWand01",
                GlobalConstants.DOUBLE_SWORD => "DoubleSword01",
                GlobalConstants.SWORD_SHIELD => "SwordShield01",
                GlobalConstants.TWO_HANDS_SWORD => "TwoHandsSword01",
                _ => "Secret01"
            };
        }
    }
}
