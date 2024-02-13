using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class LuckySpinReward : MonoBehaviour
    {
        public int RewardValue { get; private set; }
        private Collider _collider;

        public void Start()
        {
            _collider = GetComponent<Collider>();
        }
        
        public void DisableCollider()
        {
            _collider.enabled = false;
        }

        public void EnableCollider()
        {
            _collider.enabled = true;
        }

        public void Initialize(int rewardGold, int rewardHealth, int rewardDiamond)
        {
            RewardValue = gameObject.tag switch
            {
                GlobalConstants.REWARD_GOLD => rewardGold,
                GlobalConstants.REWARD_HEALTH => rewardHealth,
                GlobalConstants.REWARD_DIAMOND => rewardDiamond,
                _ => 0
            };
        }
    }
}
