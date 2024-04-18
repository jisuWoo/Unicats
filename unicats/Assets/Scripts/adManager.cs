using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class adManager : MonoBehaviour
{
    private RewardedAd rewardedAd;

    GameManager gm;
    PlayerControl pc;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        InitAds();
        gm = FindObjectOfType<GameManager>();
        pc = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitAds()
    {
        string adUnitId;

        #if UNITY_ANDROID
                adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
                            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
                            adUnitId = "unexpected_platform";
        #endif

        RewardedAd.Load(adUnitId, new AdRequest.Builder().Build(), LoadCallback);
    }

    public void LoadCallback(RewardedAd rewardedAd, LoadAdError loadAdError)
    {
        if (rewardedAd != null)
        {
            this.rewardedAd = rewardedAd;
            Debug.Log("광고로드");
        }
        else
        {
            Debug.Log(loadAdError.GetMessage());
        }

    }

    public void ShowAds()
    {
        if (rewardedAd.CanShowAd())
        {
            rewardedAd.Show(GetReward);
        }
        else
        {
            Debug.Log("광고 시청");
        }
    }

    public void GetReward(Reward reward)
    {
        if (gm.GameState == "End")
        {
            pc.PlayerHp = pc.PlayerMaxHp;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = (new Vector3(player.transform.position.x + 4,2f,0f));      
            Time.timeScale = 1;
            gm.GameState = "Play";
        }
        InitAds();
    }
}