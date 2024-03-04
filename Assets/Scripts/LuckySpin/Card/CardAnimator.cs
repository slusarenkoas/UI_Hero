using LuckySpin.Chest;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace LuckySpin.Card
{
    public class CardAnimator : MonoBehaviour
    {
        [SerializeField] private ChestController _chest;
        [SerializeField] private TextMeshProUGUI _cardTitle;
        [SerializeField] private TextMeshProUGUI _valueReward;
        [SerializeField] private Image _image;
        
        private Animator _animator;
        
        private static readonly int RewardCard = Animator.StringToHash("RewardCard");
        private static readonly int ScullCard = Animator.StringToHash("ScullCard");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void StartCardAnimation(int value, Sprite icon, string title,bool isThisSkullCard)
        {
            _cardTitle.text = title;
            _image.sprite = icon;
            
            if (value > 0)
            { 
                _valueReward.enabled = true;
                _valueReward.text = value.ToString();
            }
            else
            {
                _valueReward.enabled = false;
            }

            _animator.SetTrigger(!isThisSkullCard ? RewardCard : ScullCard);
        }
        
        //Animation use in Scene in RewardsCardAnimation
        public void PlaySecondAnimation()
        {
           _chest.StartProcessOpeningChest();
        }
    }
}
