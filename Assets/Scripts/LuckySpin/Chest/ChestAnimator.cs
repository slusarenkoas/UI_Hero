using System;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace LuckySpin.Chest
{
    public class ChestAnimator : MonoBehaviour
    {
        public event Action ClickTakeRewardButton;
        
        [SerializeField] private Image _blackBackground;
        [SerializeField] private ChestController _chestController;

        [SerializeField] private TextMeshProUGUI _gold;
        [SerializeField] private TextMeshProUGUI _diamond;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private TextMeshProUGUI _surprise;
        [SerializeField] private AudioManager _audioManager;

        
        private Animator _animator;
        
        private static readonly int IsSpinEnded = Animator.StringToHash("isSpinEnded");
        private static readonly int StartShuffle = Animator.StringToHash("StartShuffle");
        private static readonly int OpenChest = Animator.StringToHash("OpenChest");
        private static readonly int ReturnStateChest = Animator.StringToHash("ResetChest");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartOpenChestAnimation()
        {
            _blackBackground.gameObject.SetActive(true);
            
            SetRewardsValue();

            _animator.SetBool(IsSpinEnded, true);
        }

        public void ActivateOpenChest()
        {
            _animator.SetTrigger(OpenChest);
            _audioManager.PlayLuckySpinOpenChestSound();
        }

        public void ResetChest()
        {
            _blackBackground.enabled = false;
            ClickTakeRewardButton?.Invoke();
            
            SetRewardsValue();
            _animator.SetBool(IsSpinEnded, false);

            _animator.SetTrigger(ReturnStateChest);
        }

        public void StartShuffleAnimation()
        {
            _animator.SetTrigger(StartShuffle);
        }

        private void SetRewardsValue()
        {
            _gold.text = "x " + _chestController.Gold;
            _diamond.text = "x " + _chestController.Diamond;
            _health.text = "x " + _chestController.Health;
            _surprise.text = "x " + _chestController.Surprise;
        }
    }
}
