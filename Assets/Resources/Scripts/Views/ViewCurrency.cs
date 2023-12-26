using System;
using Resources.Scripts.Currency;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ViewCurrency : MonoBehaviour
    {
        [SerializeField] private CurrencyManager _currencyManager;
        [SerializeField] private TextMeshProUGUI _gold;
        [SerializeField] private TextMeshProUGUI _diamond;

        [SerializeField] private ViewLobbyController _viewLobbyController;

        private void Awake()
        {
            _viewLobbyController.StartMenuScreenOpened += SetCurrencyValue;
            _viewLobbyController.HeroSelectionLobbyScreenOpened += SetCurrencyValue;

            _currencyManager.HeroBought += SetCurrencyValue;
        }

        private void OnDestroy()
        {
            _viewLobbyController.StartMenuScreenOpened -= SetCurrencyValue;
            _viewLobbyController.HeroSelectionLobbyScreenOpened -= SetCurrencyValue;
            
            _currencyManager.HeroBought -= SetCurrencyValue;
        }

        private void SetCurrencyValue()
        {
            _gold.text = _currencyManager.Gold.ToString();
            _diamond.text = _currencyManager.Diamond.ToString();
        }
        
    }
}