using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMovement : MonoBehaviour
{
    public bool isRotateX, isRotateY, isRotateZ;
    public bool isDim;
    public bool isTranslateX, isTranslateY, isTranslateZ;
    public float speed = 1f;

    // private Vector3 initialPos, finalPos;

    static float t=0.0f;
    float maxIntensity = 20f;
    float minIntensity = 5f;
    public Vector3 initialPos;
    float finalVal;
    public float offset;

    void Start()
    {
        initialPos = this.transform.position;

        if(isTranslateX)        finalVal = initialPos.x + offset;
        if(isTranslateY)        finalVal = initialPos.y + offset;
        if(isTranslateZ)        finalVal = initialPos.z + offset;
    }
    void Update()
    {

        if(isRotateX)
        {
            this.transform.Rotate(new Vector3(10f, 0f, 0f) * Time.deltaTime * speed);
        }
        if(isRotateY)
        {
            this.transform.Rotate(new Vector3(0f, 10f, 0f) * Time.deltaTime * speed);
        }
        if(isRotateZ)
        {
            this.transform.Rotate(new Vector3(0f, 0f, 10f) * Time.deltaTime * speed);
        }

        if(isTranslateX)
        {
            this.transform.position = new Vector3(Mathf.Lerp(initialPos.x, finalVal, t), initialPos.y, initialPos.z);
            // .. and increase the t interpolater
            t += speed * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = initialPos.x;
                initialPos.x = finalVal;
                finalVal = temp;
                t = 0.0f;
            }
        }

        if(isTranslateY)
        {
            this.transform.position = new Vector3(initialPos.x, Mathf.Lerp(initialPos.y, finalVal, t), initialPos.z);
            // .. and increase the t interpolater
            t += speed * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = initialPos.y;
                initialPos.y = finalVal;
                finalVal = temp;
                t = 0.0f;
            }
        }

        if(isTranslateZ)
        {
            this.transform.position = new Vector3(initialPos.x, initialPos.y, Mathf.Lerp(initialPos.z, finalVal, t));
            // .. and increase the t interpolater
            t += speed * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = initialPos.z;
                initialPos.z = finalVal;
                finalVal = temp;
                t = 0.0f;
            }
        }

        if(isDim)
        {
            this.transform.GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
            // .. and increase the t interpolater
            t += speed * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = maxIntensity;
                maxIntensity = minIntensity;
                minIntensity = temp;
                t = 0.0f;
            }
        }
    }
}
