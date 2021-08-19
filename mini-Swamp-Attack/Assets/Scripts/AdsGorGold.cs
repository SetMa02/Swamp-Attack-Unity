using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsGorGold : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject startWachingButton;
    [SerializeField] private Player _player;
    
    private string gameId = "4269321";
    private string myPlacmentId = "Rewarded_Android";
    private bool testMode = true;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        
        startWachingButton.GetComponent<Button>().onClick.AddListener((() =>
        {
            Advertisement.Show(myPlacmentId);
            startWachingButton.SetActive(false);
        }));
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacmentId)
        {
            startWachingButton.SetActive(true);
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            _player.AddMoney(100);
            Debug.Log("Просмотрено");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("Зафейлено");
        }
        else if (showResult == ShowResult.Skipped)
        { 
            Debug.Log("Скипнуто");

        }
    }
}
