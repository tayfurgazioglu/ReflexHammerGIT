﻿using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class OnmouseYes : MonoBehaviour {

    public GameObject MainAskScreen = null;

	void OnMouseUp()
    {
        MainAskScreen.SetActive(false);
        ShowRewardedAd();
    }




    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);

        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                DetectCollider.Life = 1;
                PlayerPrefs.SetInt("LifePoint", DetectCollider.Life);
                PlayerPrefs.Save();

                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
