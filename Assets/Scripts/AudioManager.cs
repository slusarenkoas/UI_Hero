using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _wheelRotateSound;
    [SerializeField] private AudioClip[] _luckySpinRewardCardSound;
    [SerializeField] private AudioClip _luckySpinLooseCardSound;
    [SerializeField] private AudioClip _luckySpinOpenChestSound;
    
    private AudioSource _audioSource;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayWheelRotationSound()
    {
        _audioSource.clip = _wheelRotateSound;
        _audioSource.Play();
    }
    
    public void StopWheelRotationSound()
    {
        _audioSource.Stop();
    }

    public void PlayLuckySpinLooseRewardSound()
    {
        _audioSource.clip = _luckySpinLooseCardSound;
        _audioSource.Play();
    }
    
    public void PlayLuckySpinRewardCardSound()
    {
        var randomSound = Random.Range(0, _luckySpinRewardCardSound.Length);
        _audioSource.clip = _luckySpinRewardCardSound[randomSound];
        _audioSource.Play();
    }

    public void PlayLuckySpinOpenChestSound()
    {
        _audioSource.clip = _luckySpinOpenChestSound;
        _audioSource.Play();
    }
}
