using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class ChestAnimator : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int IsSpinEnded = Animator.StringToHash("isSpinEnded");
        private static readonly int StartShuffle = Animator.StringToHash("StartShuffle");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartOpenChestAnimation()
        {
            _animator.SetBool(IsSpinEnded,true);
        }

        public void StartShuffleAnimation()
        {
            _animator.SetTrigger(StartShuffle);
        }
    }
}
