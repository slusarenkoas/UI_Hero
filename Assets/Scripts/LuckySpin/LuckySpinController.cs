using System;
using LuckySpin;
using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class LuckySpinController : MonoBehaviour
    {
        [field:SerializeField] public int Spins { get; private set; }
        [field:SerializeField] public int RewardHealth { get; private set; }
        [field:SerializeField] public int RewardGold { get; private set; }
        [field:SerializeField] public int RewardDiamond { get; private set; }

        [SerializeField] private SelectController _selectController;
        [SerializeField] private ChestController _chest;
        
        private LuckySpinReward _currentReward;

        public event Action StartRotation;

        private void Start()
        {
            _selectController.RewardSelected += SetCurrentReward;
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

        public void StartWheelRotation()
        {
            if (!HasSpins())
            {
                return;
            }
            
            Spins--;
            StartRotation?.Invoke();
        }

        public bool HasSpins()
        {
            return Spins > 0;
        }
    }
}
