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
        if (Input.GetKey(KeyCode.Escape))
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
            
            case "Projects" : x = 3450f;
                             y = 18f;
                             z = 270f;
                             break;
            
            case "Experiences" : x = 4700f;
                             y = 29f;
                             z = 400f;
                             break;
            
            case "Achievements" : x = 6300f;
                             y = 22f;
                             z = 55f;
                             break;

            default :        x = 700f;
                             y = 26f;
                             z = 300f;
                             break;
        }

        lokiVariant.transform.position = new Vector3(x, y, z);
    }
}
