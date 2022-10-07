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
    public GameObject[] handPoints;
    public Slider Distancia;
    public Text Text;
    public float HandXWorldPos;
    private string data;

 
    // Start is called before the first frame update
    void Start()
    {
        AlterarDistancia();
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
                float x = HandXWorldPos -float.Parse(points[i * 3]) / Distancia.value;
                float y = float.Parse(points[i * 3 + 1]) / Distancia.value;
                float z = float.Parse(points[i * 3 + 2]) / Distancia.value;

                handPoints[i].transform.localPosition = new Vector3(x, y, z);


            }
        }
    }

    public void FecharAplicativo()
    {
        Application.Quit();
    }

    public void AlterarDistancia()
    {
        Text.text = Distancia.value.ToString();
        if (Distancia.value >= 50 && Distancia.value < 60)
        {
            Text.text = 7.ToString() + "m";
            HandXWorldPos = 11.8f;

        }
        else if (Distancia.value >= 60 && Distancia.value < 70)
        {
            Text.text = 6.ToString() + "m";
            HandXWorldPos = 10.0f;

        }
        else if (Distancia.value >= 70 && Distancia.value < 80)
        {
            Text.text = 5.ToString() + "m";
            HandXWorldPos = 7.8f;

        }
        else if (Distancia.value >= 80 && Distancia.value < 90)
        {
            Text.text = 4.ToString() + "m";
            HandXWorldPos = 7.0f;

        }
        else if (Distancia.value >= 90 && Distancia.value <= 100)
        {
            Text.text = 3.ToString() + "m";
            HandXWorldPos = 6.2f;
        }
            
     }


}

