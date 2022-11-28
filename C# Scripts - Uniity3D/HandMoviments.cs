using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandMoviments : MonoBehaviour
{
    public HandTracking handTracking;
    public Selection selection;
    public CameraManager cameraManager;

    public static int MovPassarPorta;
    public Vector2 palmaDaMaoDireito;
    public Vector2 palmaDaMaoEsquerdo;
    public Vector2 palmaDaMao;
    public Vector2 eixoZero;
    public Vector2 eixoZeroCima;
    public Vector2 eixoZeroBaixo;
    public GameObject buttonVoltarSeleção;
    public Image circleTimer;
    public List<GameObject> messagesUI;

    public static int ListaPortaIndex;
    public static int turnRotation = 0;

    private bool mudar;
    float timer;
    float _maxTimerValue = 2f;


    bool uiMessagesAux = false;
    public static bool pinca = false;
    public static bool rotacionar = false;
    public static bool passarPorta = false;
    public static bool separarPecas = false;
    public static bool juntarPecas = false;
    public static bool abrirPorta = false;
    public static bool fecharPorta = false;

    void Start()
    {
        HideUIMessages(14);
        circleTimer.fillAmount = 0;
    }

    void Update()
    {          
        ResetDoorState();
        DetectionMoviments();
        CenterHand_PassarPorta();
    }
    

    void DetectionMoviments()
    {

        if (!UDPReceiveRe.Igual1)
        {
            if (handTracking.fingersUp[0] == 1 && handTracking.fingersUp[1] == 1 && handTracking.fingersUp[2] == 0 && handTracking.fingersUp[3] == 0 && handTracking.fingersUp[4] == 0 && !rotacionar && !passarPorta && !juntarPecas && !separarPecas && !abrirPorta && !fecharPorta)
            {
                circleTimer.fillAmount += 0.5f * Time.deltaTime;
                timer += Time.deltaTime;
                uiMessagesAux = true;
                if (uiMessagesAux)
                {
                    if (selection.DistanciaPoints >= 1.5f)
                    {
                        messagesUI[0].SetActive(true);
                        HideUIMessages(0);
                    }
                    else
                    {
                        messagesUI[1].SetActive(true);
                        HideUIMessages(1);
                    }
                    
                }
                if (timer >= _maxTimerValue)
                {
                    pinca = true;
                }
                rotacionar = false;
                passarPorta = false;
                separarPecas = false;
                juntarPecas = false;
                abrirPorta = false;
                fecharPorta = false;
                mudar = false;
            }
            else if (handTracking.fingersUp[0] == 0 && handTracking.fingersUp[1] == 0 && handTracking.fingersUp[2] == 0 && handTracking.fingersUp[3] == 0 && handTracking.fingersUp[4] == 0 && !pinca && !passarPorta && !juntarPecas && !separarPecas && !abrirPorta && !fecharPorta)
            {
                circleTimer.fillAmount += 0.5f * Time.deltaTime;
                timer += Time.deltaTime;
                uiMessagesAux = true;
                if (uiMessagesAux)
                {
                    messagesUI[2].SetActive(true);
                    HideUIMessages(2);
                }
                if (timer >= _maxTimerValue)
                {
                    rotacionar = true;                    
                }
                if (!mudar)
                {
                    TurnRotationMov();
                }
                pinca = false;
                passarPorta = false;
                separarPecas = false;
                juntarPecas = false;
                abrirPorta = false;
                fecharPorta = false;
            }
            else if (handTracking.fingersUp[0] == 1 && handTracking.fingersUp[1] == 1 && handTracking.fingersUp[2] == 1 && handTracking.fingersUp[3] == 1 && handTracking.fingersUp[4] == 1 && !rotacionar && !pinca && !juntarPecas && !separarPecas && !abrirPorta && !fecharPorta)
            {
                circleTimer.fillAmount += 0.5f * Time.deltaTime;
                timer += Time.deltaTime;
                uiMessagesAux = true;
                if (uiMessagesAux)
                {
                    messagesUI[3].SetActive(true);
                    HideUIMessages(3);
                }
                if (timer >= _maxTimerValue)
                {
                    messagesUI[4].SetActive(true);
                    passarPorta = true;
                }              
                pinca = false;
                rotacionar = false;
                separarPecas = false;
                juntarPecas = false;
                abrirPorta = false;
                fecharPorta = false;
                mudar = false;
            }
            else if (handTracking.fingersUp[0] == 0 && handTracking.fingersUp[1] == 1 && handTracking.fingersUp[2] == 1 && handTracking.fingersUp[3] == 0 && handTracking.fingersUp[4] == 0 && !rotacionar && !passarPorta && !juntarPecas && !pinca && !abrirPorta && !fecharPorta)
            {
                circleTimer.fillAmount += 0.5f * Time.deltaTime;
                timer += Time.deltaTime;
                uiMessagesAux = true;
                if (uiMessagesAux)
                {
                    if (selection.portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("abrirPorta"))
                    {
                        messagesUI[11].SetActive(true);
                        HideUIMessages(11);
                    }
                    else
                    {
                        messagesUI[5].SetActive(true);
                        HideUIMessages(5);
                    }
                }
                if (timer >= _maxTimerValue)
                {
                    separarPecas = true;        
                }             
                pinca = false;
                rotacionar = false;
                passarPorta = false;
                juntarPecas = false;
                abrirPorta = false;
                fecharPorta = false;
                mudar = false;
            }
            else if (handTracking.fingersUp[0] == 0 && handTracking.fingersUp[1] == 1 && handTracking.fingersUp[2] == 0 && handTracking.fingersUp[3] == 0 && handTracking.fingersUp[4] == 0 && !rotacionar && !passarPorta && !pinca && !separarPecas && !abrirPorta && !fecharPorta)
            {
                circleTimer.fillAmount += 0.5f * Time.deltaTime;
                timer += Time.deltaTime;
                uiMessagesAux = true;
                if (uiMessagesAux)
                {
                    if (selection.portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("abrirPorta"))
                    {
                        messagesUI[12].SetActive(true);
                        HideUIMessages(12);
                    }
                    else
                    {
                        messagesUI[6].SetActive(true);
                        HideUIMessages(6);
                    }
                }
                if (timer >= _maxTimerValue)
                {
                    juntarPecas = true;                 
                }  
                separarPecas = false;
                rotacionar = false;
                passarPorta = false;
                pinca = false;
                abrirPorta = false;
                fecharPorta = false;
                mudar = false;
            }
            else if (handTracking.fingersUp[0] == 0 && handTracking.fingersUp[1] == 1 && handTracking.fingersUp[2] == 1 && handTracking.fingersUp[3] == 1 && handTracking.fingersUp[4] == 1 && !rotacionar && !passarPorta && !pinca && !separarPecas && !juntarPecas && !fecharPorta)
            {
                circleTimer.fillAmount += 0.5f * Time.deltaTime;
                timer += Time.deltaTime;
                uiMessagesAux = true;
                if (uiMessagesAux)
                {
                    if (selection.portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("SepararPeca"))
                    {
                        messagesUI[9].SetActive(true);
                        HideUIMessages(9);
                    }
                    else
                    {
                        messagesUI[7].SetActive(true);
                        HideUIMessages(7);
                    }
                    
                }
                if (timer >= _maxTimerValue)
                {
                    abrirPorta = true;             
                }             
                juntarPecas = false;
                separarPecas = false;
                rotacionar = false;
                passarPorta = false;
                pinca = false;
                fecharPorta = false;
                mudar = false;
            }
            else if (handTracking.fingersUp[0] == 0 && handTracking.fingersUp[1] == 1 && handTracking.fingersUp[2] == 1 && handTracking.fingersUp[3] == 1 && handTracking.fingersUp[4] == 0 && !rotacionar && !passarPorta && !pinca && !separarPecas && !juntarPecas && !abrirPorta)
            {
                circleTimer.fillAmount += 0.5f * Time.deltaTime;
                timer += Time.deltaTime;
                uiMessagesAux = true;
                if (uiMessagesAux)
                {
                    if (selection.portasAnimator.GetCurrentAnimatorStateInfo(0).IsName("SepararPeca"))
                    {
                        messagesUI[10].SetActive(true);
                        HideUIMessages(10);
                    }
                    else
                    {
                        messagesUI[8].SetActive(true);
                        HideUIMessages(8);
                    }
                   
                }
                if (timer >= _maxTimerValue)
                {
                    fecharPorta = true;           
                }
                abrirPorta = false;
                juntarPecas = false;
                separarPecas = false;
                rotacionar = false;
                passarPorta = false;
                pinca = false;
                mudar = false; 
            }
            else
            {
                HideUIMessages(14);
                circleTimer.fillAmount = 0;
                timer = 0;
                uiMessagesAux = false;
                pinca = false;
                rotacionar = false;
                passarPorta = false;
                separarPecas = false;
                juntarPecas = false;
                abrirPorta = false;
                fecharPorta = false;
                mudar = false;
                palmaDaMao = Vector2.zero;
                eixoZero = Vector2.zero;               
            }

        }
    }


    private void TurnRotationMov()
    {
        if (!mudar)
        {
            turnRotation++;
            if (turnRotation >= 2) {
                turnRotation = 0;
            }
            mudar = true;
        }
       
    }
   private void HideUIMessages(int indexMessages)
    {
        for (int i = 0; i < messagesUI.Count; i++)
        {
            if (i == indexMessages)
            {
                continue;
            }
            messagesUI[i].SetActive(false);
        }
    }
    private void ResetDoorState()
    {
        if ((Vector3.Distance(handTracking.handPoints[9].transform.position, palmaDaMaoDireito) <= 5.75f && MovPassarPorta >= 0 ||
        Vector3.Distance(handTracking.handPoints[9].transform.position, palmaDaMaoEsquerdo) <= 5.75f && MovPassarPorta <= 0) && passarPorta)
        {
            selection.porta[ListaPortaIndex].GetComponent<Animator>().SetBool("juntarPeca", true);
            selection.porta[ListaPortaIndex].GetComponent<Animator>().SetBool("fecharPorta", true);
            selection.porta[ListaPortaIndex].GetComponent<Animator>().SetBool("SepararPeca", false);
            selection.porta[ListaPortaIndex].GetComponent<Animator>().SetBool("abrirPorta", false);
            selection.ButttonBack();
            buttonVoltarSeleção.SetActive(false);
            cameraManager.rotGoal = Quaternion.LookRotation((cameraManager.midCamera.position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraManager.rotGoal, cameraManager.turnSpeed);
        }
        
    }

    private void CenterHand_PassarPorta()
    {
        
        if (passarPorta)
        {
            if (palmaDaMao == Vector2.zero)
            {
                palmaDaMao = handTracking.handPoints[9].transform.position;
                palmaDaMaoDireito = new Vector2(palmaDaMao.x + 9.5f, palmaDaMao.y);
                palmaDaMaoEsquerdo = new Vector2(palmaDaMao.x - 9.5f, palmaDaMao.y);
            }
            else if (palmaDaMao != Vector2.zero)
            {
                if (Vector3.Distance(handTracking.handPoints[9].transform.position, palmaDaMaoDireito) <= 5.75f && MovPassarPorta >= 0)
                {        
                    if (ListaPortaIndex >= 0)
                    {
                        ListaPortaIndex--;
                    }
                    if (ListaPortaIndex < 0)
                    {
                        ListaPortaIndex = Camera.main.GetComponent<Selection>().porta.Count - 1;
                    }
                    MovPassarPorta = -1;                   
                }
                if (Vector3.Distance(handTracking.handPoints[9].transform.position, palmaDaMaoEsquerdo) <= 5.75f && MovPassarPorta <= 0)
                {

                    if (ListaPortaIndex < Camera.main.GetComponent<Selection>().porta.Count - 1)
                    {
                        ListaPortaIndex++;
                    }
                    else
                    {
                        ListaPortaIndex = 0;
                    }
                    MovPassarPorta = 1;
                }
            }
        }
        else
        {
            palmaDaMao = Vector2.zero;
        }
    }
}
