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

        SendDataToArduino("h");
    }

    void Update()
    {
        // 'A' Ű�� ������ �� �Ƶ��̳�� '1' ����
        if (Input.GetKeyDown(KeyCode.A))
        {
            SendDataToArduino("1");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SendDataToArduino("d");
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            SendDataToArduino("s");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            SendDataToArduino("f");
        }
        else if (Input.GetKeyUp(KeyCode.N))
        {
            SendDataToArduino("s");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            SendDataToArduino("r");
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
