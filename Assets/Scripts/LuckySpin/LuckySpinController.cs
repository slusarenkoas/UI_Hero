using System;
using LuckySpin.Chest;
using LuckySpin.Wheel;
using UnityEngine;

namespace LuckySpin
{
    public class LuckySpinController : MonoBehaviour
    {
        public event Action StartRotation;
        //[field:SerializeField] public int RewardHealth { get; private set; }
        [field:SerializeField] public int RewardGold { get; private set; }
        [field:SerializeField] public int RewardDiamond { get; private set; }

        [SerializeField] private SelectController _selectController;
        [SerializeField] private ChestController _chest;
        
        private LuckySpinReward _currentReward;
        
        private void Start()
        {
            _selectController.RewardSelected += SetCurrentReward;
        }

        public void StartWheelRotation()
        {
            var currentSpin = PrefsManager.LoadSpin();
            
            if (!HasSpins())
            {
                return;
            }
            
            currentSpin--;
            
            PrefsManager.SaveSpin(currentSpin);
            
            StartRotation?.Invoke();
        }

        public bool HasSpins()
        {
            var currentSpin = PrefsManager.LoadSpin();
            return currentSpin > 0;
        }

        public int ReturnCurrentSpin()
        {
            var currentSpin = PrefsManager.LoadSpin();
            
            return currentSpin;
        }

        private void SetCurrentReward()
        {
            _currentReward = _selectController.CurrentRewards;
            _chest.AddRewardInChest(_currentReward);
        }

        private void OnDestroy()
        {
            _selectController.RewardSelected -= SetCurrentReward;
        }
    }
}
