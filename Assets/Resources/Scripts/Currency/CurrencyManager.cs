using System;
using UnityEngine;


namespace Resources.Scripts.Currency
{
    public class CurrencyManager : MonoBehaviour
    {
       [field:SerializeField] public int Gold { get; private set; }
       [field:SerializeField] public int Diamond { get; private set; }

       public event Action HeroBought;
       
       
       public bool TryBuyCurrentHero(int priceForHero)
        {
            if (priceForHero > Gold)
            {
                return false;
            }
            
            Gold -= priceForHero;
            HeroBought?.Invoke();
            return true;
        }
    }
}
