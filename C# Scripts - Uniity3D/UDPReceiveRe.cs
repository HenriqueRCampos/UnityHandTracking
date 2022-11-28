using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Unity.VisualScripting;

public class UDPReceiveRe : MonoBehaviour
{
    public string dataAux;
    public static bool Igual1;

    public void Start()
    {
        InvokeRepeating("Compara", 0, 0.5F);
        InvokeRepeating("Compara2", 0, 0.7F);
    }


    // receive thread
    private void Compara()
    {
        dataAux =  gameObject.GetComponent<UDPReceive>().dataList;
    }
    private void Compara2()
    {
        if (dataAux == gameObject.GetComponent<UDPReceive>().dataList)
        {
            Igual1 = true;
        }
        else
        {
            Igual1 = false;
        }
    }

}
