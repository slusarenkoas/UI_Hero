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
        
        private HeroesManager _heroesManager;
        private CurrencyManager _currencyManager;
        private ViewLobbyController _viewLobbyController;
        private Hero _currentHero;

        public void Initialize(HeroesManager heroesManager, CurrencyManager currencyManager, ViewLobbyController viewLobbyController)
        {
            _viewLobbyController = viewLobbyController;
            _heroesManager = heroesManager;
            _currencyManager = currencyManager;

            _currentHero = _heroesManager.CurrentHero;
            _currentHero.gameObject.SetActive(true);
        }
        
        
        public void ViewNextHero()
        {
            _currentHero.gameObject.SetActive(false);
            _heroesManager.SetNextHero();
            _currentHero = _heroesManager.CurrentHero;
            SetHeroStats();
            SetHeroInfo();
            _currentHero.gameObject.SetActive(true);
        }

        public void ViewPreviousHero()
        {
            _currentHero.gameObject.SetActive(false);
            _heroesManager.SetPreviousHero();
            _currentHero = _heroesManager.CurrentHero;
            SetHeroStats();
            SetHeroInfo();
            _currentHero.gameObject.SetActive(true);
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
            
            _viewLobbyController.HeroSelectionLobbyOpen += SetCurrencyValue;
        }

        private void OnDestroy()
        {
            _viewLobbyController.HeroSelectionLobbyOpen -= SetCurrencyValue;
        }
    }
}
