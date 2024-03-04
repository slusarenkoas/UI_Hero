using System;
using UnityEngine;

namespace LuckySpin.Wheel
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

            _luckySpinController.StartRotation += SetStatusRewardUnSelected;
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.TryGetComponent(typeof(LuckySpinReward),out var reward))
            {
                CurrentRewards = (LuckySpinReward)reward;
                RewardSelected?.Invoke();
                
                _collider.enabled = false;
            }
        }

        private void OnDestroy()
        {
            _luckySpinController.StartRotation -= SetStatusRewardUnSelected;
        }

        private void SetStatusRewardUnSelected()
        {
            _collider.enabled = true;
        }
    }
}
