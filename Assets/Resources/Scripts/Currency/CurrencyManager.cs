using System;
using UnityEngine;


namespace Resources.Scripts.Currency
{
    public class CurrencyManager : MonoBehaviour
    {
       [SerializeField] private float _gold;
       [SerializeField] private float _diamond;

       public void Initialize()
       {
           _gold = 100f;
           _diamond = 1f;
       }
       
       public float GetValueGold()
        {
            return _gold;
        }

        public float GetValueDiamond()
        {
            return _diamond;
        }
    }
}
