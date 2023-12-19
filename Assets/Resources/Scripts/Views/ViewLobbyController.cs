using System;
using Resources.Scripts.Currency;
using Resources.Scripts.Heroes;
using UnityEngine;
using UnityEngine.Events;

namespace Resources.Scripts.Views
{
    public class ViewLobbyController : MonoBehaviour
    {
        [SerializeField] private StartMenuViewController _startMenu;
        [SerializeField] private HeroSelectionLobbyViewController _heroSelectionLobby;

        private HeroesManager _heroesManager;
        private CurrencyManager _currencyManager;
        
        public event Action StartMenuOpen;
        public event Action HeroSelectionLobbyOpen;

        public void Initialize(HeroesManager heroesManager, CurrencyManager currencyManager)
        {
            _heroesManager = heroesManager;
            _currencyManager = currencyManager;

            _startMenu.Initialize(heroesManager, currencyManager,this);
            _heroSelectionLobby.Initialize(heroesManager, currencyManager,this);
            
            EnableStartMenu();
        }
        
        public void EnableStartMenu()
        {
            _heroSelectionLobby.gameObject.SetActive(false);
            _startMenu.gameObject.SetActive(true);
            
            StartMenuOpen?.Invoke();
        }

        public void EnableHeroSelectionLobby()
        {
            _startMenu.gameObject.SetActive(false);
            _heroSelectionLobby.gameObject.SetActive(true);
            
            HeroSelectionLobbyOpen?.Invoke();    
        }

        private void CloseAllMenu()
        {
            _startMenu.gameObject.SetActive(false);
            _heroSelectionLobby.gameObject.SetActive(false);
        }
    }
}
