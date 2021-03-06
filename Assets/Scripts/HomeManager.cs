using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Video;

public class HomeManager : MonoBehaviour
{
    public GameObject nameInput;
    public static string userName;
    public GameObject continueButton;
    // bool homeScreen = true;
    public GameObject transition;
    public GameObject alertText;
    public GameObject homeScreen;
    public GameObject camera;
    public GameObject spaceShipScreen;
    public GameObject videoPanel;

    void Start()
    {
        var videoPlayer = videoPanel.GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"galaxyVideo.mp4"); 
        videoPlayer.Play();
    }


    public void takeOffButton()
    {
        userName = nameInput.GetComponent<TMP_InputField>().text;
        // username = 
        Debug.Log(userName);
        if(userName == "")
        {
            StartCoroutine(alert());
        }
        else
        {
            StartCoroutine(transitionAnimation());
        }
    }

    IEnumerator alert()
    {
        alertText.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        alertText.SetActive(false);
    }
    

    IEnumerator transitionAnimation()
    {
        continueButton.transform.DOMoveY(1300, 1f);
        yield return new WaitForSeconds(0.75f);
        transition.transform.DOScale(new Vector3(30f, 30f, 30f), 0.3f);

        yield return new WaitForSeconds(0.75f);

        homeScreen.SetActive(false);
        spaceShipScreen.SetActive(true);


        camera.transform.DOMove(new Vector3(0f, 4.7f, -7.81f), 2.5f, false);
        yield return new WaitForSeconds(0.5f);
        camera.transform.DORotate(new Vector3(29.41f, 0f, 0f), 2.5f);
    }

}
