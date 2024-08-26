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
    public string grabMessage = "GRAB"; // ��ü�� ���� �� ���� �޽���
    public string releaseMessage = "RELEASE"; // ��ü�� ���� �� ���� �޽���

    [Header("References")]
    public ArduinoSerial arduinoSerial; // ArduinoSerial ��ũ��Ʈ�� ����

    private bool isGrabbing = false; // ���� ��ü�� ��� �ִ��� ���¸� ����

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
        objectToGrab.transform.SetParent(leftHandCollider.transform); // �տ� ������Ʈ�� ����
        //objectToGrab.transform.localPosition = Vector3.zero; // �� ��ġ�� ������Ʈ ��ġ�� ����
        isGrabbing = true; // ���� ������Ʈ

        arduinoSerial.SendDataToArduino(grabMessage);
    }

    private void ReleaseObject()
    {
        objectToGrab.transform.SetParent(null); // ������Ʈ�� �տ��� �и�
        isGrabbing = false; // ���� ������Ʈ

        arduinoSerial.SendDataToArduino(releaseMessage);
    }
}