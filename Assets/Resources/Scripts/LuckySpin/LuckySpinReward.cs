using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class LuckySpinReward : MonoBehaviour
    {
        public int RewardValue { get; private set; }
        
        [SerializeField] private LuckySpinController _luckySpinController;
        
        private Collider _collider;
        
        private void Start()
        {
            SetRewardValue();
            _collider = GetComponent<Collider>();
        }

        private void SetRewardValue()
        {
            RewardValue = gameObject.tag switch
            {
                GlobalConstants.REWARD_GOLD => _luckySpinController.RewardGold,
                GlobalConstants.REWARD_HEALTH => _luckySpinController.RewardHealth,
                GlobalConstants.REWARD_DIAMOND => _luckySpinController.RewardDiamond,
                _ => 0
            };
        }

        public void DisableCollider()
        {
            _collider.enabled = false;
        }

        public void EnableCollider()
        {
            _collider.enabled = true;
        }
    }
}
