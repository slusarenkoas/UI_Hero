using System;
using Resources.Scripts.LuckySpin;
using UnityEngine;


namespace Resources.Scripts.Currency
{
    public class CurrencyManager : MonoBehaviour
    {
       [field:SerializeField] public int Gold { get; private set; }
       [field:SerializeField] public int Diamond { get; private set; }

       [SerializeField] private ChestController _luckySpinChest;
       
       public event Action ValueChanged;

       private void Start()
       {
           _luckySpinChest.TookRewards += SetRewardCurrency;
       }

       private void OnDestroy()
       {
           _luckySpinChest.TookRewards -= SetRewardCurrency;
       }

       private void SetRewardCurrency(int diamond,int gold)
       {
           Diamond += diamond;
           Gold += gold;
           
           ValueChanged?.Invoke();
       }
       
       public bool TryBuyCurrentHero(int priceForHero)
        {
            if (priceForHero > Gold)
            {
                return false;
            }
            
            Gold -= priceForHero;
            ValueChanged?.Invoke();
            return true;
        }
    }
}
