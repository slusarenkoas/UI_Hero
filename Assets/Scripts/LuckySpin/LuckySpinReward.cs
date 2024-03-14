using Resources.Scripts;
using UnityEngine;

namespace LuckySpin
{
    public class LuckySpinReward : MonoBehaviour
    {
        public int RewardValue { get; private set; }
        private Collider _collider;

        public void Initialize(int rewardGold, int rewardDiamond)
        {
            _collider = GetComponent<Collider>();
            
            RewardValue = gameObject.tag switch
            {
                GlobalConstants.REWARD_GOLD => rewardGold,
                GlobalConstants.REWARD_DIAMOND => rewardDiamond,
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
