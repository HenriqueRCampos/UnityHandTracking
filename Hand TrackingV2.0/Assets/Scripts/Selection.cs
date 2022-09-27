using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    [SerializeField] private float DistanciaPoints;
    public HandTracking handTracking;
    public Vector2 palmaDaMao;
    public Transform mid;
    public List<GameObject> door;
    public GameObject Selecionado;
    public Button Voltar;
    RaycastHit hit;
    public List<Vector3> PosOri;


    void Start()
    {
        PosOri.Add(door[0].transform.position);
        PosOri.Add(door[1].transform.position);
        Selecionado = null;
        Voltar.gameObject.SetActive(false);
        Camera.main.fieldOfView = 60;
    }


    void FixedUpdate()
    {

        if (Selecionado == null)
        {
            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            if (Input.GetMouseButtonDown(0))
            {
                //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit))
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    Selecionado = hit.collider.gameObject;
                    Voltar.gameObject.SetActive(true);
                    for (int i = 0; i < door.Count; i++)
                    {
                        if (door[i] == Selecionado)
                        {
                            door[i].SetActive(true);
                        }
                        else
                        {
                            door[i].SetActive(false);
                        }
                    }
                }
            }
        }
        if (!UDPReceiveRe.Igual1)
        {
            //  APLICA ZOOM PELA CÂMERA
            if (Movimentos.pinca)
            {
                DistanciaPoints = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[4].transform.position);

                if (DistanciaPoints >= 1)
                {

                    if (Camera.main.fieldOfView > 20)
                    {
                        Camera.main.fieldOfView -= Mathf.PingPong(0.5f, DistanciaPoints);
                    }

                }
                if (DistanciaPoints < 0.6f)
                {
                    if (Camera.main.fieldOfView < 60)
                    {
                        Camera.main.fieldOfView += Mathf.PingPong(DistanciaPoints, 0.5f);
                    }
                }
            }
            //  ROTACIONAR A CAMERA EM VOLTA DA PORTA
            if (Movimentos.rotacionar)
            {
                transform.RotateAround(mid.position, Vector3.up, 1.00f);
            }
        }

        // SEPARA AS PEÇAS DA PORTA
        if (Movimentos.desmontarPorta)
        {
            door[0].transform.position = Vector3.MoveTowards(door[0].transform.position, new Vector3(door[0].transform.position.x, door[0].transform.position.y, 0.6f), 1f * Time.deltaTime);
            door[1].transform.position = Vector3.MoveTowards(door[1].transform.position, new Vector3(door[1].transform.position.x, door[1].transform.position.y, 1f), 1f * Time.deltaTime);
        }
        if (!Movimentos.desmontarPorta)
        {
            door[0].transform.position = Vector3.MoveTowards(door[0].transform.position, PosOri[0], 1f * Time.deltaTime);
            door[1].transform.position = Vector3.MoveTowards(door[1].transform.position, PosOri[1], 1f * Time.deltaTime);
        }
    }


    public void ButttonBack()
    {
        Selecionado = null;
        Voltar.gameObject.SetActive(false);
        for (int i = 0; i < door.Count; i++)
        {
            door[i].SetActive(true);
       
        }
       
    }

    
}




/*void MovimentoPassarPorta()
{
    float distanceFingers1 = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[2].transform.position);
    float distanceFingers2 = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[5].transform.position);
    float distanceFingers3 = Vector3.Distance(handTracking.handPoints[12].transform.position, handTracking.handPoints[9].transform.position);
    float distanceFingers4 = Vector3.Distance(handTracking.handPoints[16].transform.position, handTracking.handPoints[13].transform.position);
    float distanceFingers5 = Vector3.Distance(handTracking.handPoints[20].transform.position, handTracking.handPoints[17].transform.position);

    if (distanceFingers1 >= 1 && distanceFingers2 >= 1f && distanceFingers3 >= 1f && distanceFingers4 >= 1f && distanceFingers5 >= 1f && !maoFechada && !Pinca)
    {
        passarPorta = true;
    }
    else
    {
        palmaDaMao = Vector2.zero;
        passarPorta = false;
    }

}*/
/*if (passarPorta)
           {
               if (palmaDaMao == Vector2.zero)
               {
                   palmaDaMao = (handTracking.handPoints[9].transform.position);
               }

           }*/
