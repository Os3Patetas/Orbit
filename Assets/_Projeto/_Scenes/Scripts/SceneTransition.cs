using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.Icypeak.Orbit.Scenes
{
    public class SceneTransition : MonoBehaviour
    {
        public void MainMenuScene()
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        public void GameScene()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void ConfigScene()
        {
            SceneManager.LoadScene("ConfigScene");
        }

        public void RankingScene()
        {
            SceneManager.LoadScene("RankingScene");
        }

        public void StoreScene()
        {
            SceneManager.LoadScene("StoreScene");
        }
    }
}