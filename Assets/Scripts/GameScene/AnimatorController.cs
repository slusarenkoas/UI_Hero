using UnityEngine;

namespace GameScene
{
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private MovementController _movementController;
        
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        public void Initialize(Animator animator, MovementController movementController)
        {
            _animator = animator;
            _movementController = movementController;
            
            _movementController.EnableMovingState += EnableMovingAnimation; 
            _movementController.EnableIdleState += EnableIdleAnimation; 
        }

        private void EnableIdleAnimation()
        {
            _animator.SetTrigger(Idle);
        }

        private void EnableMovingAnimation()
        {
            _animator.SetTrigger(IsMoving);
        }

        private void OnDestroy()
        {
            _movementController.EnableMovingState -= EnableMovingAnimation;
            _movementController.EnableIdleState -= EnableIdleAnimation;
        }
    }
}