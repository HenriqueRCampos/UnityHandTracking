using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using System.Linq;

public class HandTracking : MonoBehaviour
{
    
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    public string data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        string data = udpReceive.data;
        if (data.Length > 0)
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            string[] points = data.Split(",");
            for (int i = 0; i < 21; i++)
            {
                float x = 5 -float.Parse(points[i * 3]) / 100;
                float y = float.Parse(points[i * 3 + 1]) / 100;
                float z = float.Parse(points[i * 3 + 2]) / 100;

                //handPoints[i].transform.localPosition = Vector3.MoveTowards(handPoints[i].transform.localPosition, new Vector3(x, y, z), 3.5f * Time.deltaTime);
                handPoints[i].transform.localPosition = new Vector3(x, y, z);


            }
        }
    }
}
