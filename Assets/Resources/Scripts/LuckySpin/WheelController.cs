using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Resources.Scripts.LuckySpin
{
    public class WheelController : MonoBehaviour
    {
        public event Action EndRotation;
        
        [SerializeField] private Transform _playBoard;
        [SerializeField] private Button _spinButton;
        
        [SerializeField] private float _minRotationSpeed;
        [SerializeField] private float _maxRotationSpeed;
        [SerializeField] private float _minRotationTime;
        [SerializeField] private float _maxRotationTime;

        [SerializeField] private Animator _animatorSpinsCoin;
       
        private static readonly int PushedSpinButton = Animator.StringToHash("PushedSpinButton");
        
        public void StartRotateWheel()
        {
            _spinButton.interactable = false;
            _animatorSpinsCoin.SetTrigger(PushedSpinButton);
            StartCoroutine(RotationWheel());
        }

        private IEnumerator RotationWheel()
        {
            var currentTime = 0f;
            var randomSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
            var randomTime = Random.Range(_minRotationTime, _maxRotationTime);
            //Add Ler Rotation
            while (currentTime < randomTime)
            {
                _playBoard.transform.Rotate(0,0,randomSpeed * randomTime);

                currentTime += Time.deltaTime;
                yield return null;
            }
            
            EndRotation?.Invoke();
            _spinButton.interactable = true;
        }
    }
}
