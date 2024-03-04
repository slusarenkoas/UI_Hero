using Heroes;
using LuckySpin;
using TMPro;
using UnityEngine;

namespace Views
{
    public class StartMenuView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHeroName;
        [SerializeField] private GameObject _luckySpinButton;
        [SerializeField] private LuckySpinController _luckySpinController;
        
        private HeroesManager _heroesManager;

        public void Initialize(HeroesManager heroesManager)
        {
            _heroesManager = heroesManager;
        }

        private void OnEnable()
        {
            _heroesManager.ActiveHero.gameObject.SetActive(true);
            _textHeroName.text = _heroesManager.ActiveHero.PlayerName;

            if (!_luckySpinController.HasSpins())
            {
                _luckySpinButton.gameObject.SetActive(false);
            }
            else
            {
                _luckySpinButton.gameObject.SetActive(true);
            }
        }
    }
}
