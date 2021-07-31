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
    private int maxAsteroids = 3;
    public TextMeshPro playerName;

    public GameObject[] asteroids;
    void Start()
    {
        
        planetList = new GameObject[planets.transform.childCount];
        distance = new float[planets.transform.childCount];

        // get reference to characters
        for (int i = 0; i < planets.transform.childCount; i++)
        {
            planetList[i] = planets.transform.GetChild(i).gameObject;
        }

        nearestPlanet.name = planetList[0].name;
        nearestPlanet.distance = Vector3.Distance(planetList[0].transform.position, ship.transform.position);

        placeAsteroids();

        if(HomeManager.userName == null)
        {
            playerName.text = "Your Ship";
        }
        else
        {
            playerName.text = HomeManager.userName + "'s Ship";
        }

    }

    void Update()
    {
        // checkLand();
        for(int i=0 ; i<planets.transform.childCount ; i++)
        {
            distance[i] = Vector3.Distance(planetList[i].transform.position, ship.transform.position);

            if(distance[i]<5f)
            {
                landButton.SetActive(true);
                Debug.Log("land on " + planetList[i].name);
                landText.text = "Press F Key to Land on " + planetList[i].name;
                currentPlanet = planetList[i].name;

            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene("PlanetSurface");
        }
    }

    // public void checkLand()
    // {
        
    // }

    void placeAsteroids()
    {
        foreach(var ast in asteroids)
        {
            for(int i=0 ; i<maxAsteroids ; i++)
            {
                Vector3 pos = new Vector3(-40f+3*i, Random.Range(-3, 3), Random.Range(27, 40));
                Instantiate(ast, pos, Quaternion.identity);
            }
        }
    }

    public void toggleInstructions(GameObject obj)
    {
        if(obj.activeInHierarchy)
        {
            obj.SetActive(false);
            ship.SetActive(true);
        }
        else
        {
            obj.SetActive(true);
            ship.SetActive(false);
        }
    }

}
