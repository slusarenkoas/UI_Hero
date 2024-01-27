using System;
using System.Collections.Generic;
using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class LuckySpinController : MonoBehaviour
    {
        [field:SerializeField] public int Spins { get; private set; }
        
        [field:SerializeField] public int RewardHealth { get; private set; }
        [field:SerializeField] public int RewardGold { get; private set; }
        [field:SerializeField] public int RewardDiamond { get; private set; }

        [SerializeField] private WheelController _wheel;
        [SerializeField] private List <LuckySpinReward> _rewards;
        

        public event Action StartRotation;
        
        private void OnEnable()
        {
            _wheel.EndRotation += SelectReward;
        }

        private void OnDestroy()
        {
            _wheel.EndRotation -= SelectReward;
        }

        public void StartWheelRotation()
        {
            if (Spins <= 0)
            {
                return;
            }
            
            Spins--;
            StartRotation?.Invoke();
            DisableColliderRewards();
            _wheel.StartRotateWheel();
        }

        private void DisableColliderRewards()
        {
            foreach (var reward in _rewards)
            {
                reward.DisableCollider();
            }
        }

        private void SelectReward()
        {
            foreach (var reward in _rewards)
            {
                reward.EnableCollider();
            }
            
        }
    }
}
