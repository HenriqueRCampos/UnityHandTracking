using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public HandTracking handTracking;
    public CameraManager cameraManager;
    public DoorMovement doorMovementScript;
    public GameObject Selecionado;
    public Button buttonVoltarSelecao;
    public Button buttonMenu;
    public List<GameObject> porta;

    public Vector3 PosCentral;
    public Vector3 posaux;
    public Vector3 Posori;
    public Vector3 PosFinal;

    public Animator portasAnimator;
    private int PortaAntProxi;
    private RaycastHit hit;
    public float DistanciaPoints;


    void Start()
    {
        
        Selecionado = null;
        Camera.main.fieldOfView = 60;
        PosCentral = porta[0].transform.position;
        Posori = new Vector3(porta[0].transform.position.x - 3, porta[0].transform.position.y, porta[0].transform.position.z);
        PosFinal = new Vector3(porta[0].transform.position.x + 3, porta[0].transform.position.y, porta[0].transform.position.z);
    }
    private void FixedUpdate()
    {
        portasAnimator = porta[HandMoviments.ListaPortaIndex].GetComponent<Animator>();
    }
    
    void Update()
    {
        
        if (Selecionado == null && porta[HandMoviments.ListaPortaIndex].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SepararPeca"))
        {
            buttonVoltarSelecao.gameObject.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit))
                {
                    if (hit.collider.gameObject.layer == doorMovementScript.doorParts[0].layer)
                    {
                        porta[HandMoviments.ListaPortaIndex].GetComponent<DoorMovement>().Selecionar(hit.collider.gameObject);
                        Selecionado = hit.collider.gameObject;
                        buttonVoltarSelecao.gameObject.SetActive(true);
                    }

                }
            }
        }
        if (portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("inicial"))
        {
            buttonMenu.gameObject.SetActive(true);
        }
        else
        {
            buttonMenu.gameObject.SetActive(false);
        }
        if (portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("inicial") && HandMoviments.separarPecas)
        {
            portasAnimator.SetBool("SepararPeca", true);
            portasAnimator.SetBool("juntarPeca", false);
            portasAnimator.SetBool("abrirPorta", false);
            portasAnimator.SetBool("fecharPorta", false);
        }
        if (portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("SepararPeca") && HandMoviments.juntarPecas && Selecionado == null)
        {
            portasAnimator.SetBool("juntarPeca", true);
            portasAnimator.SetBool("SepararPeca", false);
            portasAnimator.SetBool("abrirPorta", false);
            portasAnimator.SetBool("fecharPorta", false);
        }
        if (portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("inicial") && HandMoviments.abrirPorta)
        {
            portasAnimator.SetBool("abrirPorta", true);
            portasAnimator.SetBool("fecharPorta", false);
            portasAnimator.SetBool("SepararPeca", false);
            portasAnimator.SetBool("juntarPeca", false);
        }
        if (portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("abrirPorta") && HandMoviments.fecharPorta)
        {
            portasAnimator.SetBool("fecharPorta", true);
            portasAnimator.SetBool("abrirPorta", false);
            portasAnimator.SetBool("SepararPeca", false);
            portasAnimator.SetBool("juntarPeca", false);
        }
        
        
        DistanciaPoints = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[4].transform.position);
        //  APLICA ZOOM PELA CÂMERA
        if (HandMoviments.pinca)
        {

            if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 20 && Selecionado == GameObject.FindWithTag("alizar"))
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midsDoorParts[0].position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 20 && Selecionado == GameObject.FindWithTag("alizar2"))
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midsDoorParts[1].position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 20 && Selecionado == GameObject.FindWithTag("folha"))
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midsDoorParts[2].position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 20 && Selecionado == GameObject.FindWithTag("folha2"))
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midsDoorParts[3].position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 3 && Selecionado == GameObject.FindWithTag("macaneta"))
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midsDoorParts[4].position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 15 && Selecionado == GameObject.FindWithTag("marco"))
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midsDoorParts[5].position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 10 && Selecionado == GameObject.FindWithTag("recheio"))
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midsDoorParts[6].position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints >= 1.5f && Camera.main.fieldOfView > 20 && Selecionado == null)
            {
                Camera.main.fieldOfView -= Mathf.PingPong(1f, DistanciaPoints);
                cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midCamera.position - transform.position).normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
            }
            else if (DistanciaPoints < 1.5f && Camera.main.fieldOfView < 60)
            {
                Camera.main.fieldOfView += Mathf.PingPong(DistanciaPoints, 1f);
            }
        }

        //passarPorta


        if (HandMoviments.MovPassarPorta == 1)
        {
            porta[HandMoviments.ListaPortaIndex].transform.position = Posori;
            porta[HandMoviments.ListaPortaIndex].SetActive(true);
            posaux = PosFinal;
            if (HandMoviments.ListaPortaIndex > 0 && HandMoviments.ListaPortaIndex < porta.Count)
            {
                PortaAntProxi = HandMoviments.ListaPortaIndex - 1;
            }
            else
            {
                PortaAntProxi = porta.Count - 1;
            }
            HandMoviments.MovPassarPorta = 2;
        }
        else if (HandMoviments.MovPassarPorta == -1)
        {
            porta[HandMoviments.ListaPortaIndex].transform.position = PosFinal;
            porta[HandMoviments.ListaPortaIndex].SetActive(true);
            posaux = Posori;
            if (HandMoviments.ListaPortaIndex < porta.Count - 1)
            {
                PortaAntProxi = HandMoviments.ListaPortaIndex + 1;
            }
            if (HandMoviments.ListaPortaIndex >= porta.Count - 1)
            {
                PortaAntProxi = 0;
            }
            HandMoviments.MovPassarPorta = -2;
        }
        else
        {
            if (HandMoviments.MovPassarPorta != 0)
            {
                if (HandMoviments.MovPassarPorta != 0 && HandMoviments.MovPassarPorta != -3 && HandMoviments.MovPassarPorta != 3)
                {

                    porta[PortaAntProxi].transform.position = Vector3.MoveTowards(porta[PortaAntProxi].transform.position, posaux, 3f * Time.deltaTime);
                    porta[PortaAntProxi].transform.localScale = Vector3.MoveTowards(porta[PortaAntProxi].transform.localScale, Vector3.zero, 2f * Time.deltaTime);
                    porta[HandMoviments.ListaPortaIndex].transform.position = Vector3.MoveTowards(porta[HandMoviments.ListaPortaIndex].transform.position, PosCentral, 3f * Time.deltaTime);
                    porta[HandMoviments.ListaPortaIndex].transform.localScale = Vector3.MoveTowards(porta[HandMoviments.ListaPortaIndex].transform.localScale, Vector3.one, 1.5f * Time.deltaTime);
                }
                if (Vector3.Distance(porta[HandMoviments.ListaPortaIndex].transform.position, PosCentral) <= 0.06f)
                {
                    for (int i = 0; i < porta.Count; i++)
                    {
                        if (i != HandMoviments.ListaPortaIndex)
                        {
                            porta[i].SetActive(false);

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

    }
    public void ButttonBack()
    {
        porta[HandMoviments.ListaPortaIndex].GetComponent<DoorMovement>().Selecionar(null);
        Selecionado = null;
    }
}





