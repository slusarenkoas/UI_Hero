using Heroes;
using UnityEngine;

namespace GameScene
{
    public class GameCameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;

        private Hero _hero;

        public void Initialize(Hero hero)
        {
            _hero = hero;
        }

        private void LateUpdate()
        {
            transform.position = _hero.gameObject.transform.position + _offset;
        }
    }
}
