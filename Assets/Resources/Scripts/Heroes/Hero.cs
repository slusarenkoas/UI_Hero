﻿using UnityEngine;

namespace Resources.Scripts.Heroes
{
    public class Hero : MonoBehaviour
    {
        public bool IsHeroBought { get; set; }
        [field:SerializeField] public float Health { get; private set; }
        [field:SerializeField] public float Attack { get; private set; }
        [field:SerializeField] public float Defense { get; private set; }
        [field:SerializeField] public float Speed { get; private set; }
        [field:SerializeField] public string ClassType { get; private set; }
        [field:SerializeField] public Sprite ClassIcon { get; private set; }
        [field:SerializeField] public int HeroPrice { get; private set; }
        [field:SerializeField] public string PlayerName { get; private set; }
        
        private HeroSettings _heroSettings;

        public void Initialize(HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;
            GetHeroSetting(name);
        }

        private void GetHeroSetting(string heroName)
        {
            Health = _heroSettings.GetHeroHealth(heroName);
            Attack = _heroSettings.GetHeroAttack(heroName);
            Defense = _heroSettings.GetHeroDefense(heroName);
            Speed = _heroSettings.GetHeroSpeed(heroName);
            ClassType = _heroSettings.GetClassName(heroName);
            ClassIcon = _heroSettings.GetClassIcon(heroName);
            HeroPrice = _heroSettings.GetHeroPrice(heroName);
            IsHeroBought = _heroSettings.GetHeroActivatedInformation(heroName);
            PlayerName = _heroSettings.GetPlayerName(heroName);
        }
    }
}