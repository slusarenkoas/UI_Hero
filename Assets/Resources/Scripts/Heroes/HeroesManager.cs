using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Heroes
{
    public class HeroesManager : MonoBehaviour
    {
        [SerializeField] private Hero[] _heroes;
        [SerializeField] private ViewHeroSelectionLobby _viewHeroSelectionLobby;
        
        private HeroSettings _heroSettings;
        private int _indexChosenHero;
        
        public Hero CurrentHeroInSelectionLobby {get; private set;}
        public Hero ActiveHero { get; private set; }

        public void Initialize (HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;

            foreach (var hero in _heroes)
            {
                hero.Initialize(_heroSettings);
            }

            if (_heroes == null) return;
            CurrentHeroInSelectionLobby =_heroes[0];
            
            ActiveHero = CurrentHeroInSelectionLobby;

            _viewHeroSelectionLobby.ExitFromSelectionLobbyController += ReturnCurrentGameViewHero;
            _viewHeroSelectionLobby.SelectNewHeroOnLobbyController += SetNewGameViewHero;
            _viewHeroSelectionLobby.CurrentHeroBought += SetViewHeroFlagIsBought;
        }

        private void SetViewHeroFlagIsBought()
        {
            CurrentHeroInSelectionLobby.IsHeroBought = true;
        }
        
        private void SetNewGameViewHero()
        {
            ActiveHero = CurrentHeroInSelectionLobby;
        }

        private void ReturnCurrentGameViewHero()
        {
            CurrentHeroInSelectionLobby = ActiveHero;

            for (var index = 0; index < _heroes.Length; index++)
            {
                var hero = _heroes[index];
                if (hero.name != ActiveHero.name) continue;
                _indexChosenHero = index;
                return;
            }
        }
       
        public void ReturnNextHero()
        {
            _indexChosenHero = (_indexChosenHero + 1) % _heroes.Length;
            CurrentHeroInSelectionLobby = _heroes[_indexChosenHero];
        }

        public void ReturnPreviousHero()
        {
            _indexChosenHero = (_indexChosenHero - 1 + _heroes.Length) % _heroes.Length;
            CurrentHeroInSelectionLobby = _heroes[_indexChosenHero];
        }
        
        private void OnDestroy()
        {
            _viewHeroSelectionLobby.ExitFromSelectionLobbyController -= ReturnCurrentGameViewHero;
            _viewHeroSelectionLobby.SelectNewHeroOnLobbyController -= SetNewGameViewHero;
            _viewHeroSelectionLobby.CurrentHeroBought -= SetViewHeroFlagIsBought;
        }
    }
}