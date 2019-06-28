using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class ADS : MonoBehaviour
{

#if UNITY_IOS
    private const string gameID = "3154661";
#elif UNITY_ADS
    private const string gameID = "3154660";
#endif

    public bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(gameID, testMode);
        
    }

    private string placementId = "video";

    public void ShowInterstialAd()
    {

        placementId = "video";
        StartCoroutine(ShowAd());

    }


    private IEnumerator ShowAd()
    {
        while(!Monetization.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.1f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;


        if (ad != null)
        {
            ad.Show();
        }
    }
    //void Update()
    //{
        //ShowAd();
    //}

    //public void ShowAd()
    //{
        //if (Advertisement.IsReady())
        //{
            //Advertisement.Show();
            //Debug.Log("Push Ads Button");
        //}
    //}
}
