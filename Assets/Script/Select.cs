using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;


public class Select : MonoBehaviour
{
    public InputActionReference aButtonAction;
    public InputActionReference bButtonAction;
    public GameObject objectToGrab;
    public Collider leftHandCollider;

    [Header("Arduino Messages")]
    public string grabMessage = "GRAB"; // 물체를 잡을 때 보낼 메시지
    public string releaseMessage = "RELEASE"; // 물체를 놓을 때 보낼 메시지

    [Header("References")]
    public ArduinoSerial arduinoSerial; // ArduinoSerial 스크립트의 참조

    private bool isGrabbing = false; // 현재 물체를 잡고 있는지 상태를 저장

    private void OnEnable()
    {
        aButtonAction.action.Enable();
        bButtonAction.action.Enable();

        aButtonAction.action.performed += OnAButtonPressed;
        bButtonAction.action.performed += OnBButtonPressed;
    }

    private void OnDisable()
    {
        aButtonAction.action.performed -= OnAButtonPressed;
        bButtonAction.action.performed -= OnBButtonPressed;

        aButtonAction.action.Disable();
        bButtonAction.action.Disable();
    }

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        if (!isGrabbing && IsHandTouchingObject())
        {
            GrabObject();
        }
    }

    private void OnBButtonPressed(InputAction.CallbackContext context)
    {
        if (isGrabbing)
        {
            ReleaseObject();
        }
    }

    private bool IsHandTouchingObject()
    {
        return leftHandCollider.bounds.Intersects(objectToGrab.GetComponent<Collider>().bounds);
    }

    private void GrabObject()
    {
        objectToGrab.transform.SetParent(leftHandCollider.transform); // 손에 오브젝트를 붙임
        //objectToGrab.transform.localPosition = Vector3.zero; // 손 위치에 오브젝트 위치를 맞춤
        isGrabbing = true; // 상태 업데이트

        arduinoSerial.SendDataToArduino(grabMessage);
    }

    private void ReleaseObject()
    {
        objectToGrab.transform.SetParent(null); // 오브젝트를 손에서 분리
        isGrabbing = false; // 상태 업데이트

        arduinoSerial.SendDataToArduino(releaseMessage);
    }
}