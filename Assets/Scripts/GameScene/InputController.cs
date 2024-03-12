using UnityEngine;
using UnityEngine.AI;

namespace GameScene
{
    public class InputController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Vector3 _targetPosition;
        private Animator _animator;
        private Camera _camera;
        
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        public void Initialize ()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit))
                {
                    _targetPosition = hit.point;
                    _navMeshAgent.SetDestination(_targetPosition);
                    _animator.SetTrigger(IsMoving);
                }
            }

            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _animator.SetTrigger(Idle);
            }
        }
    }
}
