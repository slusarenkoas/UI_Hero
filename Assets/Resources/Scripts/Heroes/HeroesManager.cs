using UnityEngine;

namespace Resources.Scripts.Heroes
{
    public class HeroesManager : MonoBehaviour
    {
        [SerializeField] private Hero[] _heroes;
        private HeroSettings _heroSettings;

        public void Initialize (HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;
            
            foreach (var hero in _heroes)
            {
                hero.Initialize(_heroSettings);
            }
        }
    }
}