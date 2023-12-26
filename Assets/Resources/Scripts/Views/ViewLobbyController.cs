using System;
using Resources.Scripts.Currency;
using Resources.Scripts.Heroes;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ViewLobbyController : MonoBehaviour
    {
        [SerializeField] private ViewStartMenu _viewStartMenu;
        [SerializeField] private ViewHeroSelectionLobby _viewHeroSelectionLobby;

        public event Action StartMenuScreenOpened;
        public event Action HeroSelectionLobbyScreenOpened;

        public void Initialize(HeroesManager heroesManager, CurrencyManager currencyManager)
        {
            _viewStartMenu.Initialize(heroesManager, currencyManager,this);
            _viewHeroSelectionLobby.Initialize(heroesManager, currencyManager,this);
            
            ShowStartMenu();
        }
        
        public void ShowStartMenu()
        {
            _viewHeroSelectionLobby.gameObject.SetActive(false);
            _viewStartMenu.gameObject.SetActive(true);
            
            StartMenuScreenOpened?.Invoke();
        }

        public void ShowHeroSelectionLobby()
        {
            _viewStartMenu.gameObject.SetActive(false);
            _viewHeroSelectionLobby.gameObject.SetActive(true);
            
            HeroSelectionLobbyScreenOpened?.Invoke();    
        }
    }
}
