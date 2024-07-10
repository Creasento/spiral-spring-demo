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
        objectRenderer.material.color = Color.blue; // ��ü�� ������ �� ������ ���������� ����
        isGrabbed = true;
    }
    public void ChangeColorYellow()
    {
        objectRenderer.material.color = Color.yellow; // ��ü�� ������ �� ������ ���������� ����
        isGrabbed = true;
    }
    public void ResetColor()
    {
        objectRenderer.material.color = originalColor; // ��ü�� ������ �� ���� �������� �ǵ���
    }
    public void ChangeRadius()
    {
        transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor) * Time.deltaTime;
    }
}
