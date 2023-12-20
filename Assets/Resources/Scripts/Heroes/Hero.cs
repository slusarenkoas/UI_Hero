using System;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.Heroes
{
    public class Hero : MonoBehaviour
    {
        [SerializeField]
        private float _health;
        [SerializeField]
        private float _attack;
        [SerializeField]
        private float _defense;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private string _textType;
        [SerializeField]
        private Sprite _classIcon;
        
        private string _nameHero;
        private HeroSettings _heroSettings;

        public void Initialize(HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;
            _nameHero = gameObject.name;
            GetHeroSetting();
        }

        private void GetHeroSetting()
        {
            _health = _heroSettings.GetHealthHero(_nameHero);
            _attack = _heroSettings.GetAttackHero(_nameHero);
            _defense = _heroSettings.GetDefenseHero(_nameHero);
            _speed = _heroSettings.GetSpeedHero(_nameHero);
            _textType = _heroSettings.GetClassName(_nameHero);
            _classIcon = _heroSettings.GetIconClass(_nameHero);
        }

        public float GetHealth()
        {
            return _health;
        }
        
        public float GetAttack()
        {
            return _attack;
        }
        
        public float GetDefense()
        {
            return _defense;
        }
        
        public float GetSpeed()
        {
            return _speed;
        }

        public string GetTextTypeHero()
        {
            return _textType;
        }

        public Sprite GetClassIcon()
        {
            return _classIcon;
        }
    }
}