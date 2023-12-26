using Resources.Scripts.Currency;
using Resources.Scripts.Heroes;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ViewStartMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHeroName;

        private HeroesManager _heroesManager;
        private CurrencyManager _currencyManager;
        private ViewLobbyController _viewLobbyController;
        
        public void Initialize(HeroesManager heroesManager, CurrencyManager currencyManager, ViewLobbyController viewLobbyController)
        {
            _viewLobbyController = viewLobbyController;
            _heroesManager = heroesManager;
            _currencyManager = currencyManager;
        }

        private void OnEnable()
        {
            _viewLobbyController.StartMenuScreenOpened += ShowOnStartMenuScreenElements;
        }

        private void OnDisable()
        {
            _viewLobbyController.StartMenuScreenOpened -= ShowOnStartMenuScreenElements;
        }

        private void ShowOnStartMenuScreenElements()
        {
            _textHeroName.text = _heroesManager.ActiveHero.PlayerName;
        }
    }
}
