using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public HandTracking handTracking;
    public CameraManager cameraManager;
    public GameObject Selecionado;
    public Button Voltar;
    public List<GameObject> porta;

    public Vector3 PosCentral;
    public Vector3 Posori;
    public Vector3 PosFinal;

    private RaycastHit hit;
    [SerializeField] private float DistanciaPoints;

    void Start()
    {

        Selecionado = null;
        Voltar.gameObject.SetActive(false);
        Camera.main.fieldOfView = 60;
        PosCentral = porta[0].transform.position;
        Posori = new Vector3(porta[0].transform.position.x-3, porta[0].transform.position.y, porta[0].transform.position.z);
        PosFinal = new Vector3(porta[0].transform.position.x + 3, porta[0].transform.position.y, porta[0].transform.position.z);
    }

    
    void FixedUpdate()
    {
        if (Selecionado == null)
        {
            //if (Input.GetMouseButtonDown(0))
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit))
                {
                    porta[HandMoviments.ListaPortaIndex].GetComponent<DoorMovement>().Selecionar(hit.collider.gameObject);
                    Selecionado = hit.collider.gameObject;
                    Voltar.gameObject.SetActive(true);
                }
            }
        }

        //  APLICA ZOOM PELA CÂMERA
        if (HandMoviments.pinca)
        {
            DistanciaPoints = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[4].transform.position);

            if (DistanciaPoints >= 1 && Camera.main.fieldOfView > 20)
            {
                Camera.main.fieldOfView -= Mathf.PingPong(0.5f, DistanciaPoints);
            }
            else if (DistanciaPoints < 0.6f && Camera.main.fieldOfView < 60)
            {
                Camera.main.fieldOfView += Mathf.PingPong(DistanciaPoints, 0.5f);
            }
        }
        
        if (HandMoviments.MovPassarPorta == 1)
        {
            porta[HandMoviments.ListaPortaIndex].transform.position = Posori;
            porta[HandMoviments.ListaPortaIndex].SetActive(true);
            HandMoviments.MovPassarPorta = 2;
        }
        if (HandMoviments.MovPassarPorta == 2)
        {
            if (porta.Count >= 2)
            {
                if (HandMoviments.ListaPortaIndex > 0 && HandMoviments.ListaPortaIndex < porta.Count)
                {
                    porta[HandMoviments.ListaPortaIndex - 1].transform.position = Vector3.LerpUnclamped(porta[HandMoviments.ListaPortaIndex - 1].transform.position, PosFinal, 3f * Time.deltaTime);
                }
                else
                {
                    porta[porta.Count - 1].transform.position = Vector3.LerpUnclamped(porta[porta.Count - 1].transform.position, PosFinal, 3f * Time.deltaTime);
                }
            }
            porta[HandMoviments.ListaPortaIndex].transform.position = Vector3.LerpUnclamped(porta[HandMoviments.ListaPortaIndex].transform.position, PosCentral, 3f * Time.deltaTime);
        }
        if (HandMoviments.MovPassarPorta == -1)
        {
            porta[HandMoviments.ListaPortaIndex].transform.position = PosFinal;
            porta[HandMoviments.ListaPortaIndex].SetActive(true);
            HandMoviments.MovPassarPorta = -2;
        }
        if (HandMoviments.MovPassarPorta == -2)
        {
            if (porta.Count >= 2)
            {

                if (HandMoviments.ListaPortaIndex < porta.Count - 1)
                {
                    porta[HandMoviments.ListaPortaIndex + 1].transform.position = Vector3.LerpUnclamped(porta[HandMoviments.ListaPortaIndex + 1].transform.position, Posori, 3f * Time.deltaTime);
                }
                if (HandMoviments.ListaPortaIndex >= porta.Count - 1)
                {
                    porta[0].transform.position = Vector3.LerpUnclamped(porta[0].transform.position, Posori, 3f * Time.deltaTime);
                }
            }
            porta[HandMoviments.ListaPortaIndex].transform.position = Vector3.LerpUnclamped(porta[HandMoviments.ListaPortaIndex].transform.position, PosCentral, 3f * Time.deltaTime);
        }
        if (HandMoviments.MovPassarPorta != 0)
        {
            if (Vector3.Distance(porta[HandMoviments.ListaPortaIndex].transform.position, PosCentral) <= 0.06f)
            {
                for (int i = 0; i < porta.Count; i++)
                {
                    if (i != HandMoviments.ListaPortaIndex)
                    {
                        porta[i].SetActive(false);
                        if (HandMoviments.MovPassarPorta < 0)
                        {
                            porta[i].transform.position = PosFinal;
                        }
                        if (HandMoviments.MovPassarPorta > 0)
                        {
                            porta[i].transform.position = Posori;
                        }
                    }
                }
                if (UDPReceiveRe.Igual1)
                {
                    Camera.main.GetComponent<HandMoviments>().palmaDaMao = Vector2.zero;
                }
                HandMoviments.MovPassarPorta = 0;
            }
        }
    }
    public void ButttonBack()
    {
        porta[HandMoviments.ListaPortaIndex].GetComponent<DoorMovement>().Selecionar(null);
        Selecionado = null;
    }
}





