using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reklam : MonoBehaviour
{
    private BannerView bannerView;

    AdSize adSize = new AdSize(250, 250);

    

    public void Start()
    {
        DontDestroyOnLoad(gameObject);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1387271040581477/2995564006";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        
        this.bannerView = new BannerView(adUnitId, adSize, AdPosition.Bottom);
    }
}
