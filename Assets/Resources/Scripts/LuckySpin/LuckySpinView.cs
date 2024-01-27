using Resources.Scripts.Views;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.LuckySpin
{
    public class LuckySpinView : MonoBehaviour
    {
        [SerializeField] private LuckySpinController _luckySpinController;
        [SerializeField] private TextMeshProUGUI _spins;
        [SerializeField] private LobbyView _lobbyView;

        private void OnEnable()
        {
            _lobbyView.PresentWheelScreenOpened += SetSpinsValue;
            _luckySpinController.StartRotation += SetSpinsValue;
        }
        
        private void OnDestroy()
        {
            _lobbyView.PresentWheelScreenOpened -= SetSpinsValue;
            _luckySpinController.StartRotation -= SetSpinsValue;
        }
        
        private void SetSpinsValue()
        {
            _spins.text ="x" +  _luckySpinController.Spins;
        }
    }
}
