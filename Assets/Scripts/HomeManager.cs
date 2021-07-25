using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HomeManager : MonoBehaviour
{
    public GameObject nameInput;
    string userName;
    public GameObject continueButton;
    // bool homeScreen = true;
    public GameObject transition;
    public GameObject alertText;
    public GameObject homeScreen;
    public GameObject camera;
    // public GameObject characterScreen;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeOffButton()
    {
        userName = nameInput.GetComponent<TMP_InputField>().text;
        Debug.Log(userName);
        if(userName == "")
        {
            StartCoroutine(alert());
        }
        else
        {
            // TODO Play flight audio
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

        yield return new WaitForSeconds(0.3f);

        homeScreen.SetActive(false);


        camera.transform.DOMove(new Vector3(0f, 0f, 0f), 2f, false);
        yield return new WaitForSeconds(0.5f);
        camera.transform.DORotate(new Vector3(0f, 0f, 0f), 2f);
    }

}
