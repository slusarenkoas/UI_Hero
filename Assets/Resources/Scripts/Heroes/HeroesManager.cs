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
        private int _indexChosenHero;
        
        public Hero ChosenHero {get; private set;}
        public Hero CurrentGameHero { get; private set; }

        public void Initialize (HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;

            foreach (var hero in _heroes)
            {
                hero.Initialize(_heroSettings);
            }

            if (_heroes == null) return;
            ChosenHero =_heroes[0];
            
            CurrentGameHero = ChosenHero;

            _heroSelectionLobby.ExitFromSelectionLobbyController += ReturnCurrentGameHero;
            _heroSelectionLobby.SelectNewHeroOnLobbyController += SetNewGameHero;
            _heroSelectionLobby.CurrentHeroBought += SetHeroFlagIsBought;
        }

        private void SetHeroFlagIsBought()
        {
            ChosenHero.IsHeroBought = true;
        }

        private void OnDestroy()
        {
            _heroSelectionLobby.ExitFromSelectionLobbyController -= ReturnCurrentGameHero;
            _heroSelectionLobby.SelectNewHeroOnLobbyController -= SetNewGameHero;
            _heroSelectionLobby.CurrentHeroBought -= SetHeroFlagIsBought;
        }

        private void SetNewGameHero()
        {
            CurrentGameHero = ChosenHero;
        }

        private void ReturnCurrentGameHero()
        {
            ChosenHero = CurrentGameHero;

            for (var index = 0; index < _heroes.Length; index++)
            {
                var hero = _heroes[index];
                if (hero.name != CurrentGameHero.name) continue;
                _indexChosenHero = index;
                return;
            }
        }

        public void ReturnNextHero()
        {
            _indexChosenHero++;
            
            if (_indexChosenHero == _heroes.Length)
            {
                _indexChosenHero = 0;
                ChosenHero = _heroes[_indexChosenHero];
                return;
            }
            
            ChosenHero = _heroes[_indexChosenHero];
        }

        public void ReturnPreviousHero()
        {
            _indexChosenHero--;
            
            if (_indexChosenHero < 0)
            {
                _indexChosenHero = _heroes.Length - 1;
                ChosenHero = _heroes[_indexChosenHero];
                return;
            }
            
            ChosenHero = _heroes[_indexChosenHero];
        }
    }
}