using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class balloon : MonoBehaviour
{
    public float scaleFactor = 0.01f;
    private Vector3 currentScale;

    private bool isGrabbed = false;
    void Start()
    {
        currentScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            // B Ű�� ������ �ְ�, ��ü�� ������ ���� ��� ������ ����
            transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor) * Time.deltaTime;
            currentScale = transform.localScale; // ���ο� ������ ����
        }

        // ���⿡ VR ��ȣ�ۿ� �Է� ó���� �߰��� �� �ֽ��ϴ�.
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            OnGrab();
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            OnRelease();
        }
    }

    public void OnGrab()
    {
        isGrabbed = true;
        Debug.Log("Object grabbed");
    }

    public void OnRelease()
    {
        isGrabbed = false;
        Debug.Log("Object released");
        transform.localScale = currentScale; // ��� ���� �� �������� ����
    }

}
