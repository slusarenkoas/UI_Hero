using Resources.Scripts.Views;
using TMPro;
using UnityEngine;
using Views;

namespace Resources.Scripts.Currency
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private CurrencyManager _currencyManager;
        [SerializeField] private TextMeshProUGUI _gold;
        [SerializeField] private TextMeshProUGUI _diamond;
        [SerializeField] private LobbyView _lobbyView;

        private void Awake()
        {
            _lobbyView.StartMenuScreenOpened += SetCurrencyValue;
            _lobbyView.HeroSelectionLobbyScreenOpened += SetCurrencyValue;
            _lobbyView.PresentWheelScreenOpened += SetCurrencyValue;
            _currencyManager.ValueChanged += SetCurrencyValue;
        }

        private void OnDestroy()
        {
            _lobbyView.StartMenuScreenOpened -= SetCurrencyValue;
            _lobbyView.HeroSelectionLobbyScreenOpened -= SetCurrencyValue;
            _lobbyView.PresentWheelScreenOpened -= SetCurrencyValue;
            _currencyManager.ValueChanged -= SetCurrencyValue;
        }

        private void SetCurrencyValue()
        {
            _gold.text = _currencyManager.Gold.ToString();
            _diamond.text = _currencyManager.Diamond.ToString();
        }
        
    }
}