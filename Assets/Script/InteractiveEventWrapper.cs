using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveEventWrapper : MonoBehaviour
{
    public UnityEvent onGrab; // ��ü�� ������ �� �߻��� �̺�Ʈ
    public UnityEvent onRelease; // ��ü�� ������ �� �߻��� �̺�Ʈ

    private void OnEnable()
    {
        // �ʱ� �����̳� �̺�Ʈ ���� �ڵ�
    }

    public void Grab()
    {
        onGrab.Invoke(); // Grab �̺�Ʈ ȣ��
    }

    public void Release()
    {
        onRelease.Invoke(); // Release �̺�Ʈ ȣ��
    }
}
