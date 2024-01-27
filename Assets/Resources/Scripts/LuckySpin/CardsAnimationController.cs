using UnityEngine;

namespace Resources.Scripts.LuckySpin
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
                    _cardAnimator.StartCardAnimation(currentRewardValue,_diamondIcon,_diamondCardText,false);
                    break;
                case GlobalConstants.REWARD_GOLD:
                    _cardAnimator.StartCardAnimation(currentRewardValue,_goldIcon,_goldCardText,false);
                    break;
                case GlobalConstants.REWARD_LOST_SPIN:
                    _cardAnimator.StartCardAnimation(currentRewardValue,_skullIcon,_skullCardText,true);
                    break; 
                case GlobalConstants.REWARD_HEALTH:
                    _cardAnimator.StartCardAnimation(currentRewardValue,_healthIcon,_healthCardText,false);
                    break;
                case GlobalConstants.REWARD_SURPRISE:
                    _cardAnimator.StartCardAnimation(currentRewardValue,_surpriseIcon,_surpriseCardText,false);
                    break;
            }
        }
    }
}
