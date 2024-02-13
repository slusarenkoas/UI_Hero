using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Resources.Scripts.LuckySpin
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private LuckySpinController _luckySpinController;
        [SerializeField] private Animator _animatorSpinsCoin;
        [SerializeField] private List <LuckySpinReward> _rewards;
        [SerializeField] private Button _spinButton;
        [SerializeField] private Transform _playBoard; 
        [SerializeField] private float _spinDuration = 5f;
        [SerializeField] private float _speedDuration = 10f;
        [SerializeField] private ParticleSystem _wheelHighLight;
        
        private static readonly int PushedSpinButton = Animator.StringToHash("PushedSpinButton");

        private void Start()
        {
            foreach (var luckySpinReward in _rewards)
            {
                luckySpinReward.Initialize(_luckySpinController.RewardGold,
                    _luckySpinController.RewardHealth,
                    _luckySpinController.RewardDiamond);
            }
            
            _luckySpinController.StartRotation += StartRotateWheel;
        }
        
        private void OnDestroy()
        {
            _luckySpinController.StartRotation -= StartRotateWheel;
        }

        private void StartRotateWheel()
        {
            _wheelHighLight.Stop();
            
            DisableColliderRewards();
            _spinButton.interactable = false;
            
            _animatorSpinsCoin.SetTrigger(PushedSpinButton);
            
            StartCoroutine(RotationWheel());
            
            StopCoroutine(RotationWheel());
            _wheelHighLight.Stop();
        }
        
        private IEnumerator RotationWheel()
        {
            _wheelHighLight.Play();
            
            var startRotation = _playBoard.rotation.eulerAngles.z; 
            var endRotation = Random.Range(startRotation + 360f,startRotation + 1440f);

            var currentTime = 0f;
            while (currentTime < 1f)
            {
                currentTime += Time.deltaTime / _spinDuration * _speedDuration; 
                _playBoard.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(startRotation, endRotation, currentTime)); 
                yield return null;
            }
            
            EnableColliderForRewardsSelected();
            
            yield return new WaitForSeconds(2f);
            
            _spinButton.interactable = true;
        }
        
        private void DisableColliderRewards()
        {
            foreach (var reward in _rewards)
            {
                reward.DisableCollider();
            }
        }

        private void EnableColliderForRewardsSelected()
        {
            foreach (var reward in _rewards)
            {
                reward.EnableCollider();
            }
        }
    }
}
