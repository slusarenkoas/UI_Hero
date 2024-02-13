using UnityEngine;

namespace Resources.Scripts.Heroes
{
    public class HeroesManager : MonoBehaviour
    {
        public Hero ActiveHero { get; private set; }
        
        [SerializeField] private Hero[] _heroes;
        [SerializeField] private HeroesSwitcher _heroesSwitcher;
        
        private HeroSettings _heroSettings;
        private int _indexChosenHero;
        
        public void Initialize (HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;

            foreach (var hero in _heroes)
            {
                hero.Initialize(_heroSettings);
            }

            if (_heroes == null) return;
            ActiveHero = _heroes[0];
            
            _heroesSwitcher.Initialize(_heroes,ActiveHero);
        }
        
        public void SetNewActiveHero(Hero newHero)
        {
            ActiveHero = newHero;
        }
    }
}