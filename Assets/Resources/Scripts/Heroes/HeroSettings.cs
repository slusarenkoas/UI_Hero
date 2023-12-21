using System;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.Heroes
{
    [Serializable]
    public class HeroSettings : MonoBehaviour
    {
        private float _health = 100f;
        private float _attack = 100f;
        private float _defense = 100f;
        private float _speed = 100f;

        [SerializeField] private Sprite _classIconDamage;
        [SerializeField] private Sprite _classIconDefender;
        [SerializeField] private Sprite _secretClass;
        
        [SerializeField] private float _lowMultiplier = 0.3f;
        [SerializeField] private float _mediumMultiplier = 0.6f;
        [SerializeField] private float _highMultiplier = 1f;
        
        public enum PriceForHero
        {
            BowHero = 1000,
            MagicWand = 2000,
            DoubleSword = 3000,
            SwordShield = 4000,
            TwoHandsSword = 5000
        }
        
        public Sprite GetIconClass(string nameHero)
        {
            switch (nameHero)
            {
                case GlobalConst.BOW_HERO:
                case GlobalConst.MAGIC_WAND:
                case GlobalConst.DOUBLE_SWORD:
                case GlobalConst.TWO_HANDS_SWORD:
                    return _classIconDamage;
                case  GlobalConst.NO_WEAPON:
                    case  GlobalConst.SWORD_SHIELD:
                    return _classIconDefender;
                default:
                    return _secretClass;
            }
        }

        public string GetClassName(string nameHero)
        {
            return nameHero switch
            {
                GlobalConst.NO_WEAPON => "No Weapon Hero",
                GlobalConst.BOW_HERO => "Bow Hero",
                GlobalConst.MAGIC_WAND => "Magic Wand Hero",
                GlobalConst.DOUBLE_SWORD => "Double Sword Hero",
                GlobalConst.SWORD_SHIELD => "Sword Shield Hero",
                GlobalConst.TWO_HANDS_SWORD => "Two Hands Sword Hero",
                _ => "Secret Hero"
            };
        }

        public float GetSpeedHero(string nameHero)
        {
            return nameHero switch
            {
                GlobalConst.NO_WEAPON => _speed * _lowMultiplier,
                GlobalConst.BOW_HERO => _speed * _highMultiplier,
                GlobalConst.MAGIC_WAND => _speed * _lowMultiplier,
                GlobalConst.DOUBLE_SWORD => _speed * _highMultiplier,
                GlobalConst.SWORD_SHIELD => _speed * _lowMultiplier,
                GlobalConst.TWO_HANDS_SWORD => _speed * _highMultiplier,
                _ => 0
            };
        }

        public float GetDefenseHero(string nameHero)
        {
            return nameHero switch
            {
                GlobalConst.NO_WEAPON => _defense * _lowMultiplier,
                GlobalConst.BOW_HERO => _defense * _lowMultiplier,
                GlobalConst.MAGIC_WAND => _defense * _lowMultiplier,
                GlobalConst.DOUBLE_SWORD => _defense * _lowMultiplier,
                GlobalConst.SWORD_SHIELD => _defense * _highMultiplier,
                GlobalConst.TWO_HANDS_SWORD => _defense * _mediumMultiplier,
                _ => 0
            };
        }

        public float GetAttackHero(string nameHero)
        {
            return nameHero switch
            {
                GlobalConst.NO_WEAPON => _attack * _lowMultiplier,
                GlobalConst.BOW_HERO => _attack * _highMultiplier,
                GlobalConst.MAGIC_WAND => _attack * _highMultiplier,
                GlobalConst.DOUBLE_SWORD => _attack * _mediumMultiplier,
                GlobalConst.SWORD_SHIELD => _attack * _lowMultiplier,
                GlobalConst.TWO_HANDS_SWORD => _attack * _highMultiplier,
                _ => 0
            };
        }

        public float GetHealthHero(string nameHero)
        {
            return nameHero switch
            {
                GlobalConst.NO_WEAPON => _health * _lowMultiplier,
                GlobalConst.BOW_HERO => _health * _lowMultiplier,
                GlobalConst.MAGIC_WAND => _health * _lowMultiplier,
                GlobalConst.DOUBLE_SWORD => _health * _mediumMultiplier,
                GlobalConst.SWORD_SHIELD => _health * _highMultiplier,
                GlobalConst.TWO_HANDS_SWORD => _health * _mediumMultiplier,
                _ => 0
            };
        }

        public int GetPriceForHero(string nameHero)
        {
            return nameHero switch
            {
                GlobalConst.BOW_HERO => (int)PriceForHero.BowHero,
                GlobalConst.MAGIC_WAND => (int)PriceForHero.MagicWand,
                GlobalConst.DOUBLE_SWORD => (int)PriceForHero.DoubleSword,
                GlobalConst.SWORD_SHIELD => (int)PriceForHero.SwordShield,
                GlobalConst.TWO_HANDS_SWORD => (int)PriceForHero.TwoHandsSword,
                _ => 0
            };
        }

        public bool GetHeroActivatedInformation(string nameHero)
        {
            return nameHero switch
            {
                GlobalConst.NO_WEAPON => true,
                _ => false
            };
        }
    }
}
