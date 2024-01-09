using System;
using Resources.Scripts.Heroes;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class LobbyView : MonoBehaviour
    {
        public event Action StartMenuScreenOpened;
        public event Action HeroSelectionLobbyScreenOpened;
        
        [SerializeField] private StartMenuView _startMenuView;
        [SerializeField] private HeroSelectionLobbyView _heroSelectionLobbyView;
        
        public void Initialize(HeroesManager heroesManager)
        {
            _startMenuView.Initialize(heroesManager);
            ShowStartMenu();
        }
        
        public void ShowStartMenu()
        {
            _heroSelectionLobbyView.gameObject.SetActive(false);
            _startMenuView.gameObject.SetActive(true);
            
            StartMenuScreenOpened?.Invoke();
        }

        public void ShowHeroSelectionLobby()
        {
            _startMenuView.gameObject.SetActive(false);
            _heroSelectionLobbyView.gameObject.SetActive(true);
            
            HeroSelectionLobbyScreenOpened?.Invoke();    
        }
    }
}
