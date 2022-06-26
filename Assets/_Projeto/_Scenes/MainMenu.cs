using UnityEngine;
using UnityEngine.SceneManagement;

using com.Icypeak.Orbit.Manager;

namespace com.Icypeak.Orbit.Scene
{
    public class MainMenu : MonoBehaviour
    {
        public void GoToChooseGameMode()
        {
            SceneManager.LoadScene("ChooseGameMode");
        }
        public void GoToOptionsScene()
        {
            SceneManager.LoadScene("Options");
        }
        public void GoToLeaderboardScene()
        {
            SceneManager.LoadScene("Leaderboard");
        }
        public void GoToStoreScene()
        {
            SceneManager.LoadScene("Store");
        }
        public void GoToTwitter()
        {
            Application.OpenURL("https://www.twitter.com");
        }
        public void GoToWebsite()
        {
            Application.OpenURL("https://www.google.com");
        }
        public void ActivateBonus()
        {
            FindObjectOfType<AdManager>().ShowRewardedInterstitialAd();
        }
    }
}
