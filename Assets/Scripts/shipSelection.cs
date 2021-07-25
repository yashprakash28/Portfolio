using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class shipSelection : MonoBehaviour
{
    private GameObject[] shipList;
    private int index = 0;

    public static GameObject currentSelectedShip;
    public GameObject continueButton;
    public GameObject transition;


    // Start is called before the first frame update
    private void Start()
    {
        index = PlayerPrefs.GetInt("ShipSelected");

        shipList = new GameObject[transform.childCount];

        // get reference to characters
        for (int i = 0; i < transform.childCount; i++)
        {
            shipList[i] = transform.GetChild(i).gameObject;
        }

        // initally toggle off their renderer
        foreach (GameObject go in shipList)
        {
            go.SetActive(false);
        }

        // toggle on selected index
        if (shipList[index])
        {
            shipList[index].SetActive(true);
        }


        currentSelectedShip = shipList[index];
    }

    public void Toggle(bool direction)   // 1 = right, 0 = left
    {
        // toggle off the current model
        shipList[index].SetActive(false);

        // check the direction and modify index
        if (direction)
        {
            index++;
            if (index == shipList.Length)
                index = 0;
        }

        if (!direction)
        {
            index--;
            if (index < 0)
                index = shipList.Length - 1;
        }

        shipList[index].SetActive(true);

        PlayerPrefs.SetInt("ShipSelected", index);

        currentSelectedShip = shipList[index];
    }

    public void PlayButton()
    {

        StartCoroutine(transitionAnimation());
    }

    IEnumerator transitionAnimation()
    {
        continueButton.transform.DOMoveY(1300, 1f);
        yield return new WaitForSeconds(0.75f);
        transition.transform.DOScale(new Vector3(30f, 30f, 30f), 0.3f);
    }

}
