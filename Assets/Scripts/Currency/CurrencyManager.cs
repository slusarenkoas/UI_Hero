using System;
using LuckySpin.Chest;
using Managers;
using UnityEngine;

namespace Currency
{
    public class CurrencyManager : MonoBehaviour
    {
        public event Action ValueChanged;

        [SerializeField] private int _startGold;
        [SerializeField] private int _startDiamond;
        [SerializeField] private int _startSpins;
        [SerializeField] private ChestController _luckySpinChest;

        private int _currentGold;
        private int _currentDiamond;
        
        public void Initialize()
        {
            PrefsManager.SaveStartCurrency(_startGold, _startDiamond, _startSpins);
            
            _currentGold = PrefsManager.LoadGold();
            _currentDiamond = PrefsManager.LoadDiamond();
            
            _luckySpinChest.TookRewards += SetRewardCurrency;
        }

        public bool TryBuyCurrentHero(int priceForHero)
        {
            if (priceForHero > _currentGold)
            {
                return false;
            }

            _currentGold -= priceForHero;
            PrefsManager.SaveGold(_currentGold);

            ValueChanged?.Invoke();
            return true;
        }

        public int ReturnCurrentGold()
        {
            return _currentGold;
        }

        public int ReturnCurrentDiamond()
        {
            return _currentDiamond;
        }

        private void OnDestroy()
        {
            _luckySpinChest.TookRewards -= SetRewardCurrency;
        }

        private void SetRewardCurrency(int gold, int diamond)
        {
            _currentDiamond += diamond;
            _currentGold += gold;

            PrefsManager.SaveDiamond(_currentDiamond);
            PrefsManager.SaveGold(_currentGold);

            ValueChanged?.Invoke();
        }
    }
}
