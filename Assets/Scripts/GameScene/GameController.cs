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
            var navMeshAgent = _hero.AddComponent<NavMeshAgent>();
            var inputController = _hero.AddComponent<InputController>();
            var animator = _hero.GetComponent<Animator>();
            var movementController = _hero.AddComponent<MovementController>();
            var animatorController = _hero.AddComponent<AnimatorController>();
            
            movementController.Initialize(navMeshAgent,inputController,animator,animatorController);
            
            
            _hero.transform.position = _startPosition.position;
            _hero.transform.rotation = _startPosition.rotation;

        }
    }
}
