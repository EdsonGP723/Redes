using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;

public class Client2 : MonoBehaviour
{
    public static Client2 instance;
    public static int dataBufferSize = 4096;

    public string ip = "127.0.0.1";
    public int port = 26950;
    public int myId = 0;
    TCP tcp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instancia existente, destruyendo objto");
            Destroy(this);
        }
    }

    private void Start()
    {
         tcp = new TCP();
    }

    public void ConnectToServer()
    {
        tcp.Connect();
    }

    public class TCP
    {
        public TcpClient socket;

        private NetworkStream stream;
        private byte[] reciveBuffer;

        public void Connect()
        {
            socket = new TcpClient
            {
                ReceiveBufferSize = dataBufferSize,
                SendBufferSize = dataBufferSize
            };
            reciveBuffer = new byte[dataBufferSize];
            socket.BeginConnect(instance.ip, instance.port, ConnectCallback, socket);
        }

        private void ConnectCallback(IAsyncResult _result)
        {
            socket.EndConnect(_result);

            if (socket.Connected)
            {
                return;
            }
            stream = socket.GetStream();
            stream.BeginRead(reciveBuffer, 0, dataBufferSize, ReciveCallback, null);
        }

        private void ReciveCallback(IAsyncResult _result)
        {
            try
            {
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0) 
                {
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(reciveBuffer, _data, _byteLength);
                stream.BeginRead(reciveBuffer,0,dataBufferSize,ReciveCallback,null);
            }
            catch (Exception e) 
            { 
                
            }
        }
    }
}
