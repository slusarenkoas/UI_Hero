using System;
using Resources.Scripts.Currency;
using Resources.Scripts.Heroes;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class StartMenuViewController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gold;
        [SerializeField] private TextMeshProUGUI _diamond;

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
            _viewLobbyController.StartMenuOpen += SetCurrencyValue;
        }

        private void OnDisable()
        {
            _viewLobbyController.StartMenuOpen -= SetCurrencyValue;
        }

        private void SetCurrencyValue()
        {
            _gold.text = _currencyManager.GetValueGold().ToString();
            _diamond.text = _currencyManager.GetValueDiamond().ToString();
        }
    }
}
