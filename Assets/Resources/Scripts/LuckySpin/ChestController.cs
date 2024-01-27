using UnityEngine;
//TODO Next step - chest logic
namespace Resources.Scripts.LuckySpin
{
    public class ChestController : MonoBehaviour
    {
        [SerializeField] private LuckySpinController _luckySpinController;
        [SerializeField] private ChestAnimator _chestAnimator;

        public void StartProcessOpeningChest()
        {
            if (_luckySpinController.Spins == 0)
            {
                _chestAnimator.StartOpenChestAnimation();
            }
            else
            {
                _chestAnimator.StartShuffleAnimation();
            }
        }
    }
}
