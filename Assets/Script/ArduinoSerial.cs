using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoSerial : MonoBehaviour
{
    private SerialPort serialPort;

    void Start()
    {
        // 시리얼 포트 설정 (포트 이름과 통신 속도)
        serialPort = new SerialPort("COM13", 9600); // Windows에서는 COM 포트 이름 사용
        // serialPort = new SerialPort("/dev/ttyUSB0", 9600); // macOS/Linux에서는 /dev/tty* 사용

        // 시리얼 포트 열기
        try
        {
            serialPort.Open();
            serialPort.ReadTimeout = 100; // 읽기 타임아웃 설정
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
        // 'A' 키가 눌렸을 때 아두이노로 '1' 전송
        if (Input.GetKeyDown(KeyCode.Q))
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
            serialPort.WriteLine(data); // 아두이노로 데이터 전송
            Debug.Log("Sent to Arduino: " + data);
        }
    }

    void OnApplicationQuit()
    {
        // 애플리케이션 종료 시 시리얼 포트 닫기
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Serial Port Closed");
        }
    }
}
