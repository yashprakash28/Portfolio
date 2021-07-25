using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float speed = 4f;
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 10f, 0f) * Time.deltaTime * speed);
    }
}
