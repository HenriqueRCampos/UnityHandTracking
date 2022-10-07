using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera main;
    public Transform mid;
    public Transform midCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            
        
        while (HandMoviments.rotacionar && !UDPReceiveRe.Igual1)
        {

            main.transform.LookAt(midCamera);
            transform.RotateAround(midCamera.position, Vector3.up, 1.00f);
        
            break;
        }
      
           
       
    }
}
