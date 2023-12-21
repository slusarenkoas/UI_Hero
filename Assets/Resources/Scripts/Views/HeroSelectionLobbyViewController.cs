using System;
using Resources.Scripts.Currency;
using Resources.Scripts.Heroes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.Views
{
    public class HeroSelectionLobbyViewController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gold;
        [SerializeField] private TextMeshProUGUI _diamond;

        [SerializeField] private Slider _healthValueViewOnStatsScreen;
        [SerializeField] private Slider _attackValueViewOnStatsScreen;
        [SerializeField] private Slider _defenseValueViewOnStatsScreen;
        [SerializeField] private Slider _speedValueViewOnStatsScreen;

        [SerializeField] private Image _iconTypeHero;
        [SerializeField] private TextMeshProUGUI _textTypeInfoHero;

        [SerializeField] private GameObject _selectMenuNonBoughtHero;
        [SerializeField] private GameObject _selectMenuBoughtHero;
        
        [SerializeField] private TextMeshProUGUI _priceForHero;
        
        
        private HeroesManager _heroesManager;
        private CurrencyManager _currencyManager;
        private ViewLobbyController _viewLobbyController;
        private Hero _currentHero;

        public event Action ExitFromSelectionLobbyController;
        public event Action SelectNewHeroOnLobbyController;
        public event Action <int> DeductedMoneyForBoughtHero;
        public event Action CurrentHeroBought;
        

        public void TryBuyCurrentHero()
        {
            if (!(_currencyManager.GetValueGold() > _currentHero.GetPriceForHero())) return;
            
            DeductedMoneyForBoughtHero?.Invoke(_currentHero.GetPriceForHero());
            SetCurrencyValue();
            
            CurrentHeroBought?.Invoke();
            ShowCurrentHeroSElection();
        }
        
        private void ShowCurrentHeroSElection()
        {
            if (_currentHero.IsHeroBought)
            {
                _selectMenuNonBoughtHero.gameObject.SetActive(false);
                _selectMenuBoughtHero.gameObject.SetActive(true);
                return;
            }
            
            _selectMenuBoughtHero.gameObject.SetActive(false);
            _selectMenuNonBoughtHero.gameObject.SetActive(true);
        }
        
        public void Initialize(HeroesManager heroesManager, CurrencyManager currencyManager, ViewLobbyController viewLobbyController)
        {
            _viewLobbyController = viewLobbyController;
            _heroesManager = heroesManager;
            _currencyManager = currencyManager;

            _currentHero = _heroesManager.ChosenHero;
            _currentHero.gameObject.SetActive(true);
        }

        public void SelectNewGameHero()
        {
            SelectNewHeroOnLobbyController?.Invoke();
        }
        
        public void ViewNextHero()
        {
            _currentHero.gameObject.SetActive(false);
            _heroesManager.ReturnNextHero();
            _currentHero = _heroesManager.ChosenHero;
            SetHeroStats();
            SetHeroInfo();
            _currentHero.gameObject.SetActive(true);
            ShowCurrentHeroSElection();
        }

        public void ViewPreviousHero()
        {
            _currentHero.gameObject.SetActive(false);
            _heroesManager.ReturnPreviousHero();
            _currentHero = _heroesManager.ChosenHero;
            SetHeroStats();
            SetHeroInfo();
            _currentHero.gameObject.SetActive(true);
            ShowCurrentHeroSElection();
        }

        private void SetHeroStats()
        {
            _healthValueViewOnStatsScreen.value = _currentHero.GetHealth() / 100;
            _attackValueViewOnStatsScreen.value = _currentHero.GetAttack() / 100;
            _defenseValueViewOnStatsScreen.value = _currentHero.GetDefense() / 100;
            _speedValueViewOnStatsScreen.value = _currentHero.GetSpeed() / 100;
        }

        private void SetHeroInfo()
        {
            _iconTypeHero.sprite = _currentHero.GetClassIcon();
            _textTypeInfoHero.text = _currentHero.GetTextTypeHero();
            _priceForHero.text = _currentHero.GetPriceForHero().ToString();
        }
        
        private void SetCurrencyValue()
        {
            _gold.text = _currencyManager.GetValueGold().ToString();
            _diamond.text = _currencyManager.GetValueDiamond().ToString();
        }
        
        private void OnEnable()
        {
            SetHeroStats();
            SetHeroInfo();
            ShowCurrentHeroSElection();
            
            _viewLobbyController.HeroSelectionLobbyOpen += SetCurrencyValue;
        }
        
        private void OnDisable()
        {
            if (_currentHero != null)
            {
                _currentHero.gameObject.SetActive(false);
                ExitFromSelectionLobbyController?.Invoke();
                _currentHero = _heroesManager.CurrentGameHero;
                SetHeroStats();
                SetHeroInfo();
                _currentHero.gameObject.SetActive(true);
            }
        }

        private void OnDestroy()
        {
            _viewLobbyController.HeroSelectionLobbyOpen -= SetCurrencyValue;
        }
    }
}
