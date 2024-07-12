using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class balloon : MonoBehaviour
{
    public GameObject Sphere;
    public float scaleFactor = 0.01f;

    void Start()
    {

    }

    void Update()
    {
        if (Sphere != null)
        {
            if (Input.GetKey(KeyCode.B))
            {
                Sphere.transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor) * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.N))
            {
                Sphere.transform.localScale -= new Vector3(scaleFactor, scaleFactor, scaleFactor) * Time.deltaTime;
            }
        }
    }

}
