using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts.Heroes
{
    public class HeroesSwitcher : MonoBehaviour
    {
        public Hero CurrentHeroInSelectionLobby { get; private set; }
        
        [SerializeField] private ViewHeroSelectionLobby _viewHeroSelectionLobby;
        [SerializeField] private HeroesManager _heroesManager;
        
        private Hero[] _heroes;
        private int _indexChosenHero;
        
        public void Initialize(Hero[] heroes, Hero activeHero)
        {
            _heroes = heroes;
            CurrentHeroInSelectionLobby = activeHero;

            _viewHeroSelectionLobby.SelectHeroOnLobbyController += SetActiveHero;
            _viewHeroSelectionLobby.ExitFromSelectionLobbyController += ReturnCurrentHero;
            _viewHeroSelectionLobby.CurrentHeroBought += SetFlagIsBought;
        }
        
        private void SetFlagIsBought()
        {
            CurrentHeroInSelectionLobby.IsHeroBought = true;
        }
        
        private void SetActiveHero()
        {
            _heroesManager.SetNewActiveHero(CurrentHeroInSelectionLobby);
        }

        private void ReturnCurrentHero()
        {
            CurrentHeroInSelectionLobby = _heroesManager.ActiveHero;

            for (var index = 0; index < _heroes.Length; index++)
            {
                var hero = _heroes[index];
                if (hero.name != _heroesManager.ActiveHero.name) continue;
                _indexChosenHero = index;
                return;
            }
        }
        
        public void SetCurrentNextHero()
        {
            _indexChosenHero = (_indexChosenHero + 1) % _heroes.Length;
            CurrentHeroInSelectionLobby = _heroes[_indexChosenHero];
        }

        public void SetCurrentPreviousHero()
        {
            _indexChosenHero = (_indexChosenHero - 1 + _heroes.Length) % _heroes.Length;
            CurrentHeroInSelectionLobby = _heroes[_indexChosenHero];
        }
        
        private void OnDestroy()
        {
            _viewHeroSelectionLobby.ExitFromSelectionLobbyController -= ReturnCurrentHero;
            _viewHeroSelectionLobby.SelectHeroOnLobbyController -= SetActiveHero;
            _viewHeroSelectionLobby.CurrentHeroBought -= SetFlagIsBought;
        }
    }
}
