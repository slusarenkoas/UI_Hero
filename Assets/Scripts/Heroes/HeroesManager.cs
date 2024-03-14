using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Heroes
{
    public class HeroesManager : MonoBehaviour
    {
        public Hero ActiveHero { get; private set; }
        
        [SerializeField] private Hero[] _heroes;
        [SerializeField] private HeroesSwitcher _heroesSwitcher;
        [SerializeField] private GameObject _listHeroesContainer;
        
        private HeroSettings _heroSettings;
        private int _indexActiveHero;

        private readonly List<string> _boughtHeroes = new();

        public void Initialize (HeroSettings heroSettings)
        {
            _heroSettings = heroSettings;

            LoadActiveHero();
            SetBoughtStatusHeroes();
            
            _heroesSwitcher.Initialize(_heroes,ActiveHero,_indexActiveHero);
        }

        private void LoadActiveHero()
        {
            if (_heroes == null) return;
            
            var activeHero = PrefsManager.LoadActiveHero();

            for (var index = 0; index < _heroes.Length; index++)
            {
                var hero = _heroes[index];
                hero.Initialize(_heroSettings);

                if (activeHero == hero.name)
                {
                    ActiveHero = hero;
                    _indexActiveHero = index;
                }

                if (activeHero == null)
                {
                    ActiveHero = _heroes[0];
                    _indexActiveHero = 0;
                }
            }
            ActiveHero.transform.parent = null;
            DontDestroyOnLoad(ActiveHero);
        }

        private void SetBoughtStatusHeroes()
        {
            var boughtHeroesString = PrefsManager.LoadBoughtHeroes();

            if (string.IsNullOrEmpty(boughtHeroesString))
            {
                _boughtHeroes?.Add(GlobalConstants.NO_WEAPON);
                PrefsManager.SaveBoughtHero(_boughtHeroes);
                boughtHeroesString = PrefsManager.LoadBoughtHeroes();
            }
            
            var boughtHeroes = boughtHeroesString.Split(',');
            _boughtHeroes.AddRange(boughtHeroes);

            if (_heroes != null)
            {
                foreach (var hero in _heroes)
                {
                    var isBought = _boughtHeroes != null && _boughtHeroes.Contains(hero.name);
                    hero.IsHeroBought = isBought;
                }
            }
        }
        
        public void SetNewActiveHero(Hero newHero)
        {
            ActiveHero.transform.parent = _listHeroesContainer.transform;
            
            ActiveHero = newHero;
            ActiveHero.transform.parent = null;
            DontDestroyOnLoad(ActiveHero);
            
            PrefsManager.SaveActiveHero(ActiveHero.name);
        }

        public void SetBoughtStatusCurrentHero(int indexChosenHero)
        {
            _heroes[indexChosenHero].IsHeroBought = true;
            
            if (!_boughtHeroes.Contains(_heroes[indexChosenHero].name))
            {
                _boughtHeroes.Add(_heroes[indexChosenHero].name);
                PrefsManager.SaveBoughtHero(_boughtHeroes);
            }
        }
    }
}