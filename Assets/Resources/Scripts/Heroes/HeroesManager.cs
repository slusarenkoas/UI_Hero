using System;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Heroes
{
    public class HeroesManager : MonoBehaviour
    {
        [SerializeField] private Hero[] _heroes;
        [SerializeField] private HeroSelectionLobbyViewController _heroSelectionLobby;
        
        private HeroSettings _heroSettings;
        public Hero CurrentHero {get; private set;}
        private int _indexCurrentHero = 0;

        public void Initialize (HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;

            foreach (var hero in _heroes)
            {
                hero.Initialize(_heroSettings);
            }
            
            if (_heroes != null) CurrentHero =_heroes[0];
        }

        public void SetNextHero()
        {
            _indexCurrentHero++;
            
            if (_indexCurrentHero == _heroes.Length)
            {
                _indexCurrentHero = 0;
                CurrentHero = _heroes[_indexCurrentHero];
                return;
            }
            CurrentHero = _heroes[_indexCurrentHero];
        }

        public void SetPreviousHero()
        {
            _indexCurrentHero--;
            
            if (_indexCurrentHero < 0)
            {
                _indexCurrentHero = _heroes.Length - 1;
                CurrentHero = _heroes[_indexCurrentHero];
                return;
            }
            CurrentHero = _heroes[_indexCurrentHero];
        }
    }
}