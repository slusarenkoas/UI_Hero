using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ScenesManager : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadSceneAsync(SceneNames.GameScene);
        }

        public void LoadLobbyScene()
        {
            SceneManager.LoadSceneAsync(SceneNames.LobbyScene);
        }
    }
}
