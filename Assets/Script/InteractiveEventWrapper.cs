using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveEventWrapper : MonoBehaviour
{
    public UnityEvent onGrab; // 객체가 잡혔을 때 발생할 이벤트
    public UnityEvent onRelease; // 객체가 놓였을 때 발생할 이벤트

    private void OnEnable()
    {
        // 초기 설정이나 이벤트 연결 코드
    }

    public void Grab()
    {
        onGrab.Invoke(); // Grab 이벤트 호출
    }

    public void Release()
    {
        onRelease.Invoke(); // Release 이벤트 호출
    }
}
