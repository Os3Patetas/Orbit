using System;
using GoogleMobileAds.Api;
using UnityEngine;

using com.Icypeak.Orbit.Player;
using com.Icypeak.Orbit.General;

namespace com.Icypeak.Orbit.Manager
{

    public class AdManager : MonoBehaviour
    {
        private RewardedInterstitialAd rewardedInterstitialAd;

        public void ShowRewardedInterstitialAd()
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

            if (rewardedInterstitialAd != null)
            {
                rewardedInterstitialAd.Show(userEarnedRewardCallback);
            }
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

        private void HandleOnAdLoaded(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdLoaded event received");
        }
        private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                                + args);
        }
        private void HandleOnAdOpened(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdOpened event received");
        }
        private void HandleOnAdClosed(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdClosed event received");
        }
        private void HandleOnAdLeavingApplication(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdLeavingApplication event received");
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

        private void userEarnedRewardCallback(Reward reward)
        {
            var playerInfo = Resources.Load<PlayerInfo>("Player/PlayerInfo");
            playerInfo.activatedBonus.ActivateBonus(CoinBonusType.OneQuarter, 1);
        }
    }
}