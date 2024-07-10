using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoSerial : MonoBehaviour
{
    private SerialPort serialPort;

    void Start()
    {
        // �ø��� ��Ʈ ���� (��Ʈ �̸��� ��� �ӵ�)
        serialPort = new SerialPort("COM7", 9600); // Windows������ COM ��Ʈ �̸� ���
        // serialPort = new SerialPort("/dev/ttyUSB0", 9600); // macOS/Linux������ /dev/tty* ���

        // �ø��� ��Ʈ ����
        try
        {
            serialPort.Open();
            serialPort.ReadTimeout = 100; // �б� Ÿ�Ӿƿ� ����
            Debug.Log("Serial Port Opened");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    void Update()
    {
        // 'A' Ű�� ������ �� �Ƶ��̳�� '1' ����
        if (Input.GetKeyDown(KeyCode.A))
        {
            SendDataToArduino("1");
        }
    }

    public void SendDataToArduino(string data)
    {
        if (serialPort.IsOpen)
        {
            serialPort.WriteLine(data); // �Ƶ��̳�� ������ ����
            Debug.Log("Sent to Arduino: " + data);
        }
    }

    void OnApplicationQuit()
    {
        // ���ø����̼� ���� �� �ø��� ��Ʈ �ݱ�
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Serial Port Closed");
        }
    }
}