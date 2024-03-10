using Heroes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace GameScene
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform _startPosition;
        [SerializeField] private GameCameraController _camera;

        private Hero _hero;
        private InputController _inputController;

        private void Awake()
        {
            _hero = FindObjectOfType<Hero>();
            SetHeroComponent();
        }

        private void Start()
        {
            MoveHeroOnScene();
            
            _camera.Initialize(_hero);
        }

        private void SetHeroComponent()
        {
            var mainScene = SceneManager.GetSceneByName(SceneNames.GameScene);
            SceneManager.MoveGameObjectToScene(_hero.gameObject, mainScene);
        }

        private void MoveHeroOnScene()
        {
            _hero.AddComponent<NavMeshAgent>();
            var inputController = _hero.AddComponent<InputController>();
            
            _hero.transform.position = _startPosition.position;
            _hero.transform.rotation = _startPosition.rotation;
            
            inputController.Initialize();

        }
    }
}
