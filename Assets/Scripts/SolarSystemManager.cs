using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class SolarSystemManager : MonoBehaviour
{
    class NearestPlanet
    {
        public float distance;
        public string name;
    }
    NearestPlanet nearestPlanet = new NearestPlanet();
    private GameObject[] planetList;
    public GameObject planets;
    public GameObject ship;
    private string currShip;
    // public GameObject camera;
    private float[] distance;
    public GameObject landButton;
    public TMP_Text landText;
    public static string currentPlanet;

    // KeyValuePair<string, float> nearestPlanet;// = new KeyValuePair<string, float>();
        
    // Start is called before the first frame update
    void Start()
    {
        // nearestPlanet = new KeyValuePair<string, float>();
        
        planetList = new GameObject[planets.transform.childCount];
        distance = new float[planets.transform.childCount];

        // get reference to characters
        for (int i = 0; i < planets.transform.childCount; i++)
        {
            planetList[i] = planets.transform.GetChild(i).gameObject;
            // Debug.Log(planetList[i].name);
        }

        nearestPlanet.name = planetList[0].name;
        nearestPlanet.distance = Vector3.Distance(planetList[0].transform.position, ship.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        for(int i=0 ; i<planets.transform.childCount ; i++)
        {
            distance[i] = Vector3.Distance(planetList[i].transform.position, ship.transform.position);

            if(distance[i]<2.5f)
            {
                landButton.SetActive(true);
                Debug.Log("land on " + planetList[i].name);
                landText.text = "Click here to Land on " + planetList[i].name;
                currentPlanet = planetList[i].name;

            }
        }
    }

    // TODO multiple asteroids

    public void land()
    {
        SceneManager.LoadScene("PlanetSurface");
    }
}
