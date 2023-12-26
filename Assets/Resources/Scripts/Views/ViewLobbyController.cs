using System;
using Resources.Scripts.Heroes;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ViewLobbyController : MonoBehaviour
    {
        public event Action StartMenuScreenOpened;
        public event Action HeroSelectionLobbyScreenOpened;
        
        [SerializeField] private ViewStartMenu _viewStartMenu;
        [SerializeField] private ViewHeroSelectionLobby _viewHeroSelectionLobby;
        
        public void Initialize(HeroesManager heroesManager)
        {
            _viewStartMenu.Initialize(heroesManager);
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
