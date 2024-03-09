using Currency;
using Heroes;
using UnityEngine;
using Views;

namespace Managers
{
    public class 
        GameManager : MonoBehaviour
    {
        [SerializeField] private HeroesManager _heroesManager;
        [SerializeField] private LobbyView _lobbyView;
        [SerializeField] private HeroSettings _heroSettings;
        [SerializeField] private CurrencyManager _currencyManager;

        private void Start()
        {
            _currencyManager.Initialize();
            _heroesManager.Initialize(_heroSettings);
            _lobbyView.Initialize(_heroesManager);
        }
    }
}