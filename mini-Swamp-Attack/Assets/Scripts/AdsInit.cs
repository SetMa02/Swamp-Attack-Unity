using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    private string gameId = "4269321";
    private bool testMode = true;

    private void Awake()
    {
        Advertisement.Initialize(gameId, testMode);
         StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("Banner_Android"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show("Banner_Android" );
    }
}
