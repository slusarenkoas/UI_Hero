using System;
using Currency;
using Heroes;
using UnityEngine;
using Views;

public class 
    GameManager : MonoBehaviour
{
    [SerializeField] private HeroesManager _heroesManager;
    [SerializeField] private LobbyView _lobbyView;
    [SerializeField] private HeroSettings _heroSettings;
    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private SaveManager _saveManager;

    private void Start()
    {
        _currencyManager.Initialize();
        _heroesManager.Initialize(_heroSettings);
        _lobbyView.Initialize(_heroesManager);
    }
}