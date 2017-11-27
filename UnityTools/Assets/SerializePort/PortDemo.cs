// ========================================================
// 描 述：
// 作 者：xzf 
// 创建时间：2017/11/27 14:50:42
// 版 本：v 1.0
// ========================================================
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using UnityEngine;
using System.IO.Ports;

public class PortDemo : MonoBehaviour {

    //下位机回送的命令长度
    static int BUFFER_SIZE = 61;

    SerialPort port;

    Thread reciverThread;

    void Start() {
        if (OpenPort("COM4")) {
            Debug.Log("打开串口COM4成功");
        }
    }

    private void OnDestroy()
    {
        port.Close();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Send And Receive")) {
            portSend();
        }
    }

    bool OpenPort(string portName)
    {
        if (port == null)
        {
            try
            {
                port = new SerialPort(portName, 9600);
                port.ReadTimeout = 1000;
                port.WriteTimeout = 1000;
                port.WriteBufferSize = 1000;
                port.ReadBufferSize = 1000;
                port.Open();

                reciverThread = new Thread(receive);
                reciverThread.IsBackground = true;
                reciverThread.Start();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        else
        {
            Debug.Log("串口已经打开");
        }
        return false;
    }

    void portSend() {
        if (port == null)
            return;
        try
        {
            //写入16进制数eb 90 ff ff
            byte[] cmd = new byte[4];
            cmd[0] = 0xeb;
            cmd[1] = 0x90;
            cmd[2] = 0xff;
            cmd[3] = 0xff;
            port.Write(cmd, 0, 4);
            print("write: " + cmd.ToString() + " ,缓冲区:" + port.BytesToWrite);
        }
        catch (Exception e) {
            Debug.LogError(e);
        }
    }

    void receive()
    {
        while (port != null)
        {
            Thread.Sleep(1);
            try
            {
                int currentLength = port.BytesToRead;
                if (port.BytesToRead == BUFFER_SIZE)
                {
                    byte[] buffer = new Byte[BUFFER_SIZE];
                    port.Read(buffer, 0, BUFFER_SIZE);
                    string ss = byteToHexStr(buffer); //用到函数byteToHexStr
                    Debug.Log(ss);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    //字节数组转16进制字符串
    public static string byteToHexStr(byte[] bytes)
    {
        string returnStr = "";
        if (bytes != null)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                returnStr += bytes[i].ToString("X2");
            }
        }
        return returnStr;
    }
}
