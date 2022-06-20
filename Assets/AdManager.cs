using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace com.Icypeak.Orbit
{
    public class AdManager : MonoBehaviour
    {
        public static AdManager Instance;
        private RewardedInterstitialAd rewardedInterstitialAd;

        public void Awake()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void Start()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
			string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
			string adUnitId = "unexpected_platform";
#endif

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded ad with the request.
            RewardedInterstitialAd.LoadAd(adUnitId, request, adLoadCallback);
        }

        private void adLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
        {
            if (error == null)
            {
                rewardedInterstitialAd = ad;

                rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += HandleAdFailedToPresent;
                rewardedInterstitialAd.OnAdDidPresentFullScreenContent += HandleAdDidPresent;
                rewardedInterstitialAd.OnAdDidDismissFullScreenContent += HandleAdDidDismiss;
                rewardedInterstitialAd.OnPaidEvent += HandlePaidEvent;
            }
        }

        private void HandleAdFailedToPresent(object sender, AdErrorEventArgs args)
        {
            print("Rewarded interstitial ad has failed to present.");
        }

        private void HandleAdDidPresent(object sender, EventArgs args)
        {
            print("Rewarded interstitial ad has presented.");
        }

        private void HandleAdDidDismiss(object sender, EventArgs args)
        {
            print("Rewarded interstitial ad has dismissed presentation.");
        }

        private void HandlePaidEvent(object sender, AdValueEventArgs args)
        {
            print("Rewarded interstitial ad has received a paid event.");
        }
        public void ShowRewardedInterstitialAd()
        {
            if (rewardedInterstitialAd != null)
            {
                rewardedInterstitialAd.Show(userEarnedRewardCallback);
            }
        }

        private void userEarnedRewardCallback(Reward reward)
        {
            print("voce foi recompensado");
        }

    }
}
