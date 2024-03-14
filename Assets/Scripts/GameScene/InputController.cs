using System;
using UnityEngine;

namespace GameScene
{
    public class InputController : MonoBehaviour
    {
        public event Action StartMovement;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartMovement?.Invoke();
            }
        }
    }
}
