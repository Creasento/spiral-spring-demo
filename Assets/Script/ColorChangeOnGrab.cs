using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOnGrab : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public float scaleFactor = 0.01f;
    private bool isGrabbed = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    void Update()
    {
        if (isGrabbed && Input.GetKey(KeyCode.B))
        {
            ChangeRadius();
        }
    }
    public void ChangeColorBlue()
    {
        objectRenderer.material.color = Color.blue; // 객체가 잡혔을 때 색상을 빨간색으로 변경
        isGrabbed = true;
    }
    public void ChangeColorYellow()
    {
        objectRenderer.material.color = Color.yellow; // 객체가 잡혔을 때 색상을 빨간색으로 변경
        isGrabbed = true;
    }
    public void ResetColor()
    {
        objectRenderer.material.color = originalColor; // 객체가 놓였을 때 원래 색상으로 되돌림
    }
    public void ChangeRadius()
    {
        transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor) * Time.deltaTime;
    }
}
