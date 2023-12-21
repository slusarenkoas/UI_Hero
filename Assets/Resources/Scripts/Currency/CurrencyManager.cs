using System;
using Resources.Scripts.Views;
using UnityEngine;


namespace Resources.Scripts.Currency
{
    public class CurrencyManager : MonoBehaviour
    {
       [SerializeField] private int _gold = 10000;
       [SerializeField] private int _diamond = 10;
       
       [SerializeField] private HeroSelectionLobbyViewController _heroSelectionLobby;

       public void Initialize()
       {
           _gold = 10000; 
           _diamond = 10;
           
           _heroSelectionLobby.DeductedMoneyForBoughtHero += BuyCurrentHero;
       }

       private void OnDestroy()
       {
           _heroSelectionLobby.DeductedMoneyForBoughtHero -= BuyCurrentHero;
       }

       public int GetValueGold()
        {
            return _gold;
        }

        public int GetValueDiamond()
        {
            return _diamond;
        }

        private void BuyCurrentHero(int priceForHero)
        {
            _gold -= priceForHero;
        }
    }
}
