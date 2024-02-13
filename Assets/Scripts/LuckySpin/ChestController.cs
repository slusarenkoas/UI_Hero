using System;
using UnityEngine;
namespace Resources.Scripts.LuckySpin
{
    public class ChestController : MonoBehaviour
    {
        public event Action<int, int> TookRewards; 

        [SerializeField] private LuckySpinController _luckySpinController;
        [SerializeField] private ChestAnimator _chestAnimator;
       
        public int Gold { get; private set; }
        public int Diamond { get; private set; }
        public int Health { get; private set; }
        public int Surprise { get; private set; }

        private void Start()
        {
            _chestAnimator.ClickTakeRewardButton += ResetRewardsValue;
        }

        private void ResetRewardsValue()
        {
            TookRewards?.Invoke(Gold, Diamond);
            
            Gold = 0;
            Diamond = 0;
            Health = 0;
            Surprise = 0;
        }

        private void OnDestroy()
        {
            _chestAnimator.ClickTakeRewardButton -= ResetRewardsValue;
        }

        public void StartProcessOpeningChest()
        {
            if (!_luckySpinController.HasSpins())
            {
                _chestAnimator.StartOpenChestAnimation();
            }
            else
            {
                _chestAnimator.StartShuffleAnimation();
            }
        }

        public void AddRewardInChest(LuckySpinReward currentReward)
        {
            var currentTagCard = currentReward.tag;

            switch (currentTagCard)
            {
                case GlobalConstants.REWARD_DIAMOND:
                    Diamond += currentReward.RewardValue;
                    break;
                case GlobalConstants.REWARD_GOLD:
                    Gold += currentReward.RewardValue;
                    break;
                case GlobalConstants.REWARD_HEALTH:
                    Health++;
                    break;
                case GlobalConstants.REWARD_SURPRISE:
                    Surprise++;
                    break;
            }
        }
    }
}
