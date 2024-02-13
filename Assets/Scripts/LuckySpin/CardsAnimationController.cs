using Resources.Scripts;
using Resources.Scripts.LuckySpin;
using UnityEngine;

namespace LuckySpin
{
    public class CardsAnimationController : MonoBehaviour
    {
        [SerializeField] private CardAnimator _cardAnimator;
        [SerializeField] private SelectController _selectController;

        [SerializeField] private Sprite _diamondIcon;
        [SerializeField] private Sprite _goldIcon;
        [SerializeField] private Sprite _skullIcon;
        [SerializeField] private Sprite _healthIcon;
        [SerializeField] private Sprite _surpriseIcon;

        [SerializeField] private string _diamondCardText;
        [SerializeField] private string _goldCardText;
        [SerializeField] private string _skullCardText;
        [SerializeField] private string _healthCardText;
        [SerializeField] private string _surpriseCardText;

        [SerializeField] private AudioManager _audioManager;
        private void Start()
        {
            _selectController.RewardSelected += StartCardAnimation;
        }

        private void OnDestroy()
        {
            _selectController.RewardSelected -= StartCardAnimation;
        }
        
        private void StartCardAnimation()
        {
            var currentTagCard = _selectController.CurrentRewards.tag;
            var currentRewardValue = _selectController.CurrentRewards.RewardValue;

            switch (currentTagCard)
            {
                case GlobalConstants.REWARD_DIAMOND:
                    _audioManager.PlayLuckySpinRewardCardSound();
                    _cardAnimator.StartCardAnimation(currentRewardValue,_diamondIcon,_diamondCardText,false);
                    break;
                case GlobalConstants.REWARD_GOLD:
                    _audioManager.PlayLuckySpinRewardCardSound();
                    _cardAnimator.StartCardAnimation(currentRewardValue,_goldIcon,_goldCardText,false);
                    break;
                case GlobalConstants.REWARD_LOST_SPIN:
                    _audioManager.PlayLuckySpinLooseRewardSound();
                    _cardAnimator.StartCardAnimation(currentRewardValue,_skullIcon,_skullCardText,true);
                    break; 
                case GlobalConstants.REWARD_HEALTH:
                    _audioManager.PlayLuckySpinRewardCardSound();
                    _cardAnimator.StartCardAnimation(currentRewardValue,_healthIcon,_healthCardText,false);
                    break;
                case GlobalConstants.REWARD_SURPRISE:
                    _audioManager.PlayLuckySpinRewardCardSound();
                    _cardAnimator.StartCardAnimation(currentRewardValue,_surpriseIcon,_surpriseCardText,false);
                    break;
            }
        }
    }
}
