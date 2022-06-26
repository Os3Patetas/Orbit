using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace com.Icypeak.Orbit
{
    public class AdManager : MonoBehaviour
    {
        public static AdManager Instance;
        private RewardedInterstitialAd rewardedInterstitialAd;
        private BannerView bannerView;

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
            DontDestroyOnLoad(this.gameObject);
        }

        public void RequestBanner()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif


            this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

            // Called when an ad request has successfully loaded.
            this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();

            this.bannerView.LoadAd(request);
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
            this.RequestBanner();

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

        public void HandleOnAdLoaded(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdLoaded event received");
        }

        public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                                + args);
        }

        public void HandleOnAdOpened(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdOpened event received");
        }

        public void HandleOnAdClosed(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdClosed event received");
        }

        public void HandleOnAdLeavingApplication(object sender, EventArgs args)
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
