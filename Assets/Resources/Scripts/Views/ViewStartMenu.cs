using Resources.Scripts.Heroes;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Views
{
    public class ViewStartMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHeroName;

        private HeroesManager _heroesManager;

        public void Initialize(HeroesManager heroesManager)
        {
            _heroesManager = heroesManager;
        }

        private void OnEnable()
        {
            _heroesManager.ActiveHero.gameObject.SetActive(true);
            _textHeroName.text = _heroesManager.ActiveHero.PlayerName;
        }
    }
}
