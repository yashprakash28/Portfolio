using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSurfaceManager : MonoBehaviour
{
    public GameObject lokiVariant;
    public string activePlanet;
    void Start()
    {

        activePlanet = SolarSystemManager.currentPlanet;

        placePlayerOnPlanet(activePlanet);
    }  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Data");
        }
        
    }

    void placePlayerOnPlanet(string planet)
    {
        float x = 700f;
        float y = 26f;
        float z = 300f;

        switch (planet)
        {
            case "AboutMe" : x = 700f;
                             y = 26f;
                             z = 300f;
                             break;

            case "Skills" : x = 1800f;
                             y = 31f;
                             z = 388;
                             break;
            
            case "Projects" : x = 3399f;
                             y = 22f;
                             z = 388f;
                             break;
            
            case "Experiences" : x = 4837f;
                             y = 37f;
                             z = 365f;
                             break;
            
            case "Achievements" : x = 6327f;
                             y = 19f;
                             z = 117f;
                             break;

            default :        x = 700f;
                             y = 26f;
                             z = 300f;
                             break;
        }

        lokiVariant.transform.position = new Vector3(x, y, z);
    }
}
