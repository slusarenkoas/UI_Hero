using System;
using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class SelectController : MonoBehaviour
    {
        [SerializeField] private LuckySpinController _luckySpinController;
        public LuckySpinReward CurrentRewards { get; private set; }
        public event Action RewardSelected;

        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_luckySpinController.HasSpins())
            {
                _collider.enabled = true;
            }
            
            if (other.gameObject.TryGetComponent(typeof(LuckySpinReward),out var reward))
            {
                CurrentRewards = (LuckySpinReward)reward;
                RewardSelected?.Invoke();
            }
            
            if (!_luckySpinController.HasSpins())
            {
                _collider.enabled = false;
            }
        }
    }
}
