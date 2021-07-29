using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SolarSystemManager : MonoBehaviour
{
    private string currShip;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("ShipSelectedName"));
        currShip = PlayerPrefs.GetString("ShipSelectedName");

        // var shipPrefab = Resources.Load("SpaceshipPrefabs/" + currShip) as GameObject;
        // var muzzleFlash = GameObject.Instantiate(shipPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        camera.transform.DOMove(new Vector3(-1.604f, 0.14f, -1.34f), 2f, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO multiple asteroids
}
