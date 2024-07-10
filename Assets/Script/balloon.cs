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
            // B 키가 눌러져 있고, 물체가 잡히지 않은 경우 스케일 증가
            transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor) * Time.deltaTime;
            currentScale = transform.localScale; // 새로운 스케일 저장
        }

        // 여기에 VR 상호작용 입력 처리를 추가할 수 있습니다.
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
        transform.localScale = currentScale; // 잡기 해제 후 스케일을 유지
    }

}
