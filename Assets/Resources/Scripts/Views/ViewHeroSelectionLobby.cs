using System;
using Resources.Scripts.Currency;
using Resources.Scripts.Heroes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.Views
{
    public class ViewHeroSelectionLobby : MonoBehaviour
    {
        public event Action ExitFromSelectionLobbyController;
        public event Action SelectHeroOnLobbyController; 
        public event Action CurrentHeroBought;
        
        [SerializeField] private TextMeshProUGUI _heroPrice;
        [SerializeField] private TextMeshProUGUI _textHeroType;
        [SerializeField] private TextMeshProUGUI _textHeroName;

        [SerializeField] private Slider _healthValueOnStatsScreen;
        [SerializeField] private Slider _attackValueOnStatsScreen;
        [SerializeField] private Slider _defenseValueOnStatsScreen;
        [SerializeField] private Slider _speedValueOnStatsScreen;

        [SerializeField] private Image _heroTypeIcon;

        [SerializeField] private Button _buttonHeroBuy;
        [SerializeField] private Button _buttonHeroSelect;
        
        [SerializeField] private CurrencyManager _currencyManager;
        [SerializeField] private HeroesSwitcher _heroesSwitcher;

        public void BuyCurrentHero()
        {
            var isHeroBought = _currencyManager.TryBuyCurrentHero
                (_heroesSwitcher.CurrentHeroInSelectionLobby.HeroPrice);
            
            if (!isHeroBought)
            {
                return;
            }

            CurrentHeroBought?.Invoke();
            ShowCurrentHeroSelection();
        }

        public void SelectNewGameHero()
        {
            SelectHeroOnLobbyController?.Invoke();
        }

        public void ViewNextHero()
        {
            _heroesSwitcher.CurrentHeroInSelectionLobby.gameObject.SetActive(false);
            _heroesSwitcher.SetCurrentNextHero();
            SetHeroStats();
            SetHeroInfo();
            _heroesSwitcher.CurrentHeroInSelectionLobby.gameObject.SetActive(true);
            
            ShowCurrentHeroSelection();
        }

        public void ViewPreviousHero()
        {
            _heroesSwitcher.CurrentHeroInSelectionLobby.gameObject.SetActive(false);
            _heroesSwitcher.SetCurrentPreviousHero();
            SetHeroStats();
            SetHeroInfo();
            _heroesSwitcher.CurrentHeroInSelectionLobby.gameObject.SetActive(true);
            
            ShowCurrentHeroSelection();
        }
        
        private void ShowCurrentHeroSelection()
        {
            if (_heroesSwitcher.CurrentHeroInSelectionLobby.IsHeroBought)
            {
                _buttonHeroBuy.gameObject.SetActive(false);
                _buttonHeroSelect.gameObject.SetActive(true);
                return;
            }
           
            _buttonHeroSelect.gameObject.SetActive(false);
            _buttonHeroBuy.gameObject.SetActive(true);
        }
        
        private void SetHeroStats()
        {
           _healthValueOnStatsScreen.value = 
               _heroesSwitcher.CurrentHeroInSelectionLobby.Health;
           _attackValueOnStatsScreen.value = 
               _heroesSwitcher.CurrentHeroInSelectionLobby.Attack;
           _defenseValueOnStatsScreen.value = 
               _heroesSwitcher.CurrentHeroInSelectionLobby.Defense;
           _speedValueOnStatsScreen.value = 
               _heroesSwitcher.CurrentHeroInSelectionLobby.Speed;
        }

        private void SetHeroInfo()
        {
            _heroTypeIcon.sprite = _heroesSwitcher.CurrentHeroInSelectionLobby.ClassIcon;
            _textHeroType.text = _heroesSwitcher.CurrentHeroInSelectionLobby.ClassType;
            _heroPrice.text = _heroesSwitcher.CurrentHeroInSelectionLobby.HeroPrice.ToString();
            _textHeroName.text = _heroesSwitcher.CurrentHeroInSelectionLobby.PlayerName;
        }
        
        private void OnEnable()
        {
            _heroesSwitcher.CurrentHeroInSelectionLobby.gameObject.SetActive(true);
            SetHeroStats();
            SetHeroInfo();
            ShowCurrentHeroSelection();
        }
        
        private void OnDisable()
        {
            if (_heroesSwitcher.CurrentHeroInSelectionLobby == null) return;
            _heroesSwitcher.CurrentHeroInSelectionLobby.gameObject.SetActive(false);
            ExitFromSelectionLobbyController?.Invoke();
            _heroesSwitcher.CurrentHeroInSelectionLobby.gameObject.SetActive(true);
        }
    }
}
