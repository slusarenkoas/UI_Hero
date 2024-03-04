using Currency;
using UnityEngine;
using Views;

namespace Heroes
{
    public class HeroesSwitcher : MonoBehaviour
    {
        public Hero CurrentHeroInSelectionLobby { get; private set; }
        
        [SerializeField] private HeroSelectionLobbyView _heroSelectionLobbyView;
        [SerializeField] private HeroesManager _heroesManager;
        [SerializeField] private CurrencyManager _currencyManager;
        
        private Hero[] _heroes;
        private int _indexChosenHero;
        
        public void Initialize(Hero[] heroes, Hero activeHero, int indexActiveHero)
        {
            _heroes = heroes;
            CurrentHeroInSelectionLobby = activeHero;
            _indexChosenHero = indexActiveHero;

            _heroSelectionLobbyView.SelectHeroOnLobbyController += SetActiveHero;
            _heroSelectionLobbyView.ExitFromSelectionLobbyController += ResetCurrentHero;
        }

        public bool TryBuyCurrentHero()
        {
            var isHeroBought = _currencyManager.
                TryBuyCurrentHero(CurrentHeroInSelectionLobby.HeroPrice);
            
            if (!isHeroBought)
            {
                return false;
            }

            _heroesManager.SetBoughtStatusCurrentHero(_indexChosenHero);

            return true;
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

        public void HideCurrentHero()
        {
            CurrentHeroInSelectionLobby.gameObject.SetActive(false);
        }

        public void ShowCurrentHero()
        {
            CurrentHeroInSelectionLobby.gameObject.SetActive(true);
        }
        
        
        private void SetActiveHero()
        {
            _heroesManager.SetNewActiveHero(CurrentHeroInSelectionLobby);
        }

        private void ResetCurrentHero()
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
        
        private void OnDestroy()
        {
            _heroSelectionLobbyView.ExitFromSelectionLobbyController -= ResetCurrentHero;
            _heroSelectionLobbyView.SelectHeroOnLobbyController -= SetActiveHero;
        }
    }
}
