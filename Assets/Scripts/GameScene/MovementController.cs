using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace GameScene
{
    public class MovementController : MonoBehaviour
    {
        public event Action EnableMovingState;
        public event Action EnableIdleState;
        
        private NavMeshAgent _navMeshAgent;
        private Vector3 _targetPosition;
        private Camera _camera;
        private InputController _inputController;
        private AnimatorController _animatorController;
        private bool _isMoving;

        public void Initialize (NavMeshAgent navMeshAgent,InputController inputController,Animator animator,AnimatorController animatorController)
        {
            _navMeshAgent = navMeshAgent;
            _inputController = inputController;
            _camera = Camera.main;
            _animatorController = animatorController;

            _inputController.StartMovement += Move;
            
            _animatorController.Initialize(animator,this);
        }

        private void Update()
        {
            if (!_isMoving)
            {
                return;
            }
            
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_navMeshAgent.pathPending)
            {
                EnableIdleState?.Invoke();
                _isMoving = false;
            }
        }

        private void Move()
        {
            if (_isMoving)
            {
                EnableIdleState?.Invoke();
            }
            
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit)) 
            {
                _targetPosition = hit.point;
                _navMeshAgent.SetDestination(_targetPosition);
                EnableMovingState?.Invoke();
                _isMoving = true;
            }
        }
        
        private void OnDestroy()
        {
            _inputController.StartMovement -= Move;
        }
    }
}