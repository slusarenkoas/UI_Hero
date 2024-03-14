using System;
using Managers;
using UnityEngine;

namespace LuckySpin.Chest
{
    public class ChestController : MonoBehaviour
    {
        public event Action<int, int> TookRewards; 
        
        public int Gold { get; private set; }
        public int Diamond { get; private set; }
        public int Health { get; private set; }
        public int Surprise { get; private set; }

        [SerializeField] private LuckySpinController _luckySpinController;
        [SerializeField] private ChestAnimator _chestAnimator;
        
        [SerializeField] private SaveManager _saveManager;
        
        private void Start()
        {
            _saveManager.UpdateChestAwards += LoadAwards;
            _saveManager.LoadLuckyChestAward();
            
            _chestAnimator.ClickTakeRewardButton += ResetRewardsValue;
        }

        private void LoadAwards(int gold, int diamond, int surprise, int health)
        {
            Gold = gold;
            Diamond = diamond;
            Health = health;
            Surprise = surprise;
        }

        private void ResetRewardsValue()
        {
            TookRewards?.Invoke(Gold, Diamond);
            
            _saveManager.SaveChestAwardsData(0,0,0,0);
        }

        private void OnDestroy()
        {
            _chestAnimator.ClickTakeRewardButton -= ResetRewardsValue;
            _saveManager.UpdateChestAwards -= LoadAwards;
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

            _saveManager.SaveChestAwardsData(Gold, Diamond, Surprise, Health);
        }
    }
}
