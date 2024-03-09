using Heroes;
using UnityEngine;
using UnityEngine.AI;

namespace GameScene
{
    public class InputController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        public void Initialize ()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out var hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
