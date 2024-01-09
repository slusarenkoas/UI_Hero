using Resources.Scripts.Heroes;
using Resources.Scripts.Views;
using UnityEngine;

namespace Resources.Scripts
{
    public class 
        GameManager : MonoBehaviour
    {
        [SerializeField] private HeroesManager _heroesManager;
        [SerializeField] private LobbyView _lobbyView;
        [SerializeField] private HeroSettings _heroSettings;

        private void Awake()
        {
            _heroesManager.Initialize(_heroSettings);
            _lobbyView.Initialize(_heroesManager);
        }
    }
}
