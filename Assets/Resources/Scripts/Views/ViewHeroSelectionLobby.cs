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
        [SerializeField] private TextMeshProUGUI _heroPrice;
        [SerializeField] private TextMeshProUGUI _textHeroType;
        [SerializeField] private TextMeshProUGUI _textHeroName;

        [SerializeField] private Slider _healthValueViewOnStatsScreen;
        [SerializeField] private Slider _attackValueViewOnStatsScreen;
        [SerializeField] private Slider _defenseValueViewOnStatsScreen;
        [SerializeField] private Slider _speedValueViewOnStatsScreen;

        [SerializeField] private Image _heroTypeIcon;

        [SerializeField] private Button _buttonHeroBuy;
        [SerializeField] private Button _buttonHeroSelect;

        private HeroesManager _heroesManager;
        private CurrencyManager _currencyManager;
        private Hero _currentHero;

        public event Action ExitFromSelectionLobbyController;
        public event Action SelectNewHeroOnLobbyController; 
        public event Action CurrentHeroBought;
        
        public void Initialize(HeroesManager heroesManager, CurrencyManager currencyManager, ViewLobbyController viewLobbyController)
        {
            _heroesManager = heroesManager;
            _currencyManager = currencyManager;

            _currentHero = _heroesManager.CurrentHeroInSelectionLobby;
            _currentHero.gameObject.SetActive(true);
        }

        public void BuyCurrentHero()
        {
            var isHeroBought = _currencyManager.TryBuyCurrentHero(_currentHero.HeroPrice);

            if (!isHeroBought)
            {
                return;
            }

            CurrentHeroBought?.Invoke();
            ShowCurrentHeroSelection();
        }

        public void SelectNewGameHero()
        {
            SelectNewHeroOnLobbyController?.Invoke();
        }

        public void ViewNextHero()
        {
            _currentHero.gameObject.SetActive(false);
            _heroesManager.ReturnNextHero();
            _currentHero = _heroesManager.CurrentHeroInSelectionLobby;
            SetHeroStats();
            SetHeroInfo();
            _currentHero.gameObject.SetActive(true);
            ShowCurrentHeroSelection();
        }

        public void ViewPreviousHero()
        {
            _currentHero.gameObject.SetActive(false);
            _heroesManager.ReturnPreviousHero();
            _currentHero = _heroesManager.CurrentHeroInSelectionLobby;
            SetHeroStats();
            SetHeroInfo();
            _currentHero.gameObject.SetActive(true);
            ShowCurrentHeroSelection();
        }
        
        private void ShowCurrentHeroSelection()
        {
            if (_currentHero.IsHeroBought)
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
            _healthValueViewOnStatsScreen.value = _currentHero.Health / 100;
            _attackValueViewOnStatsScreen.value = _currentHero.Attack / 100;
            _defenseValueViewOnStatsScreen.value = _currentHero.Defense / 100;
            _speedValueViewOnStatsScreen.value = _currentHero.Speed / 100;
        }

        private void SetHeroInfo()
        {
            _heroTypeIcon.sprite = _currentHero.ClassIcon;
            _textHeroType.text = _currentHero.ClassType;
            _heroPrice.text = _currentHero.HeroPrice.ToString();
            _textHeroName.text = _currentHero.PlayerName;
        }
        
        private void OnEnable()
        {
            SetHeroStats();
            SetHeroInfo();
            ShowCurrentHeroSelection();
        }
        
        private void OnDisable()
        {
            if (_currentHero != null)
            {
                _currentHero.gameObject.SetActive(false);
                ExitFromSelectionLobbyController?.Invoke();
                _currentHero = _heroesManager.ActiveHero;
                SetHeroStats();
                SetHeroInfo();
                _currentHero.gameObject.SetActive(true);
            }
        }
    }
}
