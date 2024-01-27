using System;
using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class SelectController : MonoBehaviour
    {
        public LuckySpinReward CurrentRewards { get; private set; }
        public event Action RewardSelected; 

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(typeof(LuckySpinReward),out var reward))
            {
                CurrentRewards = (LuckySpinReward)reward;
                RewardSelected?.Invoke();
            }
        }
    }
}
