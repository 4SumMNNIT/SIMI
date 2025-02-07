using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Unity.VisualScripting;

public class UDPReceive : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client; 
    public int port = 5020;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public void Start()
    {
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }


    // receive thread
    private void ReceiveData()
    {

        client = new UdpClient(port);
        while (startRecieving)
        {

            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                string data = Encoding.UTF8.GetString(dataByte);
                UDPManager.Instance.SetData(data);

                if (printToConsole) { print(UDPManager.Instance.GetData()); }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

}
