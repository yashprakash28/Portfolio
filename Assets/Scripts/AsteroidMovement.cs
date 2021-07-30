using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public bool rotX, rotY, rotZ;
    public float rotSpeed;
    public float translateValue;
    void Update()
    {
        this.transform.Translate(translateValue, 0f, 0f);
        if(this.transform.position.x > 40)
        {
            this.transform.position = new Vector3(-40, Random.Range(-3, 3), Random.Range(27, 40));
        }

        if(rotX)
        {
            this.transform.Rotate(new Vector3(Random.Range(0f, 10f), 0f, 0f) * Time.deltaTime * rotSpeed);
        }
        if(rotY)
        {
            this.transform.Rotate(new Vector3(0f, Random.Range(0f, 10f), 0f) * Time.deltaTime * rotSpeed);
        }
        if(rotZ)
        {
            this.transform.Rotate(new Vector3(0f, 0f, Random.Range(0f, 10f)) * Time.deltaTime * rotSpeed);
        }
        
    }
}
