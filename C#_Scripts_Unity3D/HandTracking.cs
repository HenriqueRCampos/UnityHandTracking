using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class HandTracking : MonoBehaviour
{
    
    public UDPReceive udpReceive;
    public List<string> points;
    public List<int> BboxAlturaLargura;
    public List<int> fingersUp;
    public GameObject[] handPoints;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.dataList;
        if (data.Length > 0)
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            string[] dataaux = data.Split(",");
            points = new List<string>();
            BboxAlturaLargura = new List<int>();
            fingersUp = new List<int>();
            for(int i=0; i < 63; i++)
            {
                points.Add(dataaux[i]);
            }
            for (int i = 63; i < 65; i++)
            {
              
               BboxAlturaLargura.Add(int.Parse(dataaux[i]));
            }
            for (int i = 65; i < 70; i++)
            {

                fingersUp.Add(int.Parse(dataaux[i]));

            }
            for (int i = 0; i < 21; i++)
            {
                float x = 5 - float.Parse(points[i * 3]) / BboxAlturaLargura[1] * 5;
                float y = float.Parse(points[i * 3 + 1]) / BboxAlturaLargura[1] * 5;
                float z = float.Parse(points[i * 3 + 2]) / BboxAlturaLargura[1] * 5;

                handPoints[i].transform.localPosition = new Vector3(x, y, z);
            }
        }

    }

    public void FecharAplicativo()
    {
        Application.Quit();
    }

}

