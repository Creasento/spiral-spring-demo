using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class balloon : MonoBehaviour
{
    public GameObject Sphere;
    public float scaleFactor = 0.01f;

    public GameObject targetObject;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetObject)
        {
            Debug.Log(1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == targetObject)
        {
            Debug.Log(0);
        }
    }
}
