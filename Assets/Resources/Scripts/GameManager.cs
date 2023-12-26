using Resources.Scripts.Currency;
using Resources.Scripts.Heroes;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts
{
    public class 
        GameManager : MonoBehaviour
    {
        [SerializeField] private HeroesManager _heroesManager;
        [SerializeField] private CurrencyManager _currencyManager;
        [SerializeField] private ViewLobbyController _viewLobbyController;
    
        [SerializeField] private HeroSettings _heroSettings;

        private void Awake()
        {
            _heroesManager.Initialize(_heroSettings);
            _viewLobbyController.Initialize(_heroesManager,_currencyManager);
        }
    }
}
