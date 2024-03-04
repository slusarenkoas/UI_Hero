using System;
using LuckySpin;
using LuckySpin.Chest;
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

        public void Initialize()
        {
            PrefsManager.SaveStartCurrency(_startGold, _startDiamond, _startSpins);

            _luckySpinChest.TookRewards += SetRewardCurrency;
        }

        public bool TryBuyCurrentHero(int priceForHero)
        {
            var currentGold = PrefsManager.LoadGold();

            if (priceForHero > currentGold)
            {
                return false;
            }

            currentGold -= priceForHero;
            PrefsManager.SaveGold(currentGold);

            ValueChanged?.Invoke();
            return true;
        }

        public int ReturnCurrentGold()
        {
            return PrefsManager.LoadGold();
        }

        public int ReturnCurrentDiamond()
        {
            return PrefsManager.LoadDiamond();
        }

        private void OnDestroy()
        {
            _luckySpinChest.TookRewards -= SetRewardCurrency;
        }

        private void SetRewardCurrency(int gold, int diamond)
        {
            var currentDiamond = PrefsManager.LoadDiamond();
            var currentGold = PrefsManager.LoadGold();

            currentDiamond += diamond;
            currentGold += gold;

            PrefsManager.SaveDiamond(currentDiamond);
            PrefsManager.SaveGold(currentGold);

            ValueChanged?.Invoke();
        }
    }
}
