using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class Client : MonoBehaviour
{
    private string host = "127.0.0.1";
    private int port = 13;

    // Start is called before the first frame update
    void Start()
    {
        try 
        {
            TcpClient client = new TcpClient(host,port);
            NetworkStream ns = client.GetStream();
            byte[] byteTime = new byte[1024];
            int bytesRead = ns.Read(byteTime,0,byteTime.Length);
            Debug.Log(Encoding.ASCII.GetString(byteTime,0,bytesRead));
            client.Close();
        }
        catch(Exception ex) 
        {
            Debug.Log(ex.ToString());
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
