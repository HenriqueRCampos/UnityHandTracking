using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMoviments : MonoBehaviour
{
    public HandTracking handTracking;

    public float dis_PolegarCenter;
    public float dis_IndicadorCenter;
    public float dis_DedoMeioCenter;
    public float dis_AnelarCenter;
    public float dis_MinguinhoCenter;

    public float dis_PolegarIndicador;
    public float dis_PolegarDedoMeio;
    public float dis_PolegarAnelar;
    public float dis_PolegarMinguinho;

    public static int MovPassarPorta;
    public Vector2 palmaDaMaoDireito;
    public Vector2 palmaDaMaoEsquerdo;
    public Vector2 palmaDaMao;
    public static int ListaPortaIndex;

    public static bool pinca = false;
    public static bool rotacionar = false;
    public static bool passarPorta = false;

    void Start()
    {
        
    }

    void Update()
    {
        DetectionMoviments();
        CenterHand_PassarPorta();
    }

    void DetectionMoviments()
    {
        dis_PolegarCenter = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[15].transform.position);
        dis_IndicadorCenter = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[5].transform.position);
        dis_DedoMeioCenter = Vector3.Distance(handTracking.handPoints[12].transform.position, handTracking.handPoints[9].transform.position);
        dis_AnelarCenter = Vector3.Distance(handTracking.handPoints[16].transform.position, handTracking.handPoints[13].transform.position);
        dis_MinguinhoCenter = Vector3.Distance(handTracking.handPoints[20].transform.position, handTracking.handPoints[17].transform.position);

        dis_PolegarIndicador = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[8].transform.position);
        dis_PolegarDedoMeio = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[12].transform.position);
        dis_PolegarAnelar = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[16].transform.position);
        dis_PolegarMinguinho = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[20].transform.position);

        if (!UDPReceiveRe.Igual1)
        {
            if (dis_MinguinhoCenter <= 0.89f && dis_AnelarCenter <= 0.89f && dis_DedoMeioCenter <= 0.89f && dis_PolegarCenter >= 0.6f && dis_IndicadorCenter >= 0.55f)
            {
                pinca = true;
                rotacionar = false;
                passarPorta = false;

                Debug.Log("Movimento Pinça");
            }
            else if (dis_MinguinhoCenter <= 0.89f && dis_AnelarCenter <= 0.89f && dis_DedoMeioCenter <= 0.89f && dis_PolegarCenter < 0.45f && dis_IndicadorCenter < 0.55f)
            {
                rotacionar = true;
                pinca = false;
                passarPorta = false;

                Debug.Log("Movimento Rotacionar");
            }
            else if (dis_MinguinhoCenter >= 0.89f && dis_AnelarCenter >= 0.89f && dis_DedoMeioCenter >= 0.89f && dis_PolegarCenter >= 1.1f && dis_IndicadorCenter >= 1.1f)
            {
                passarPorta = true;
                pinca = false;
                rotacionar = false;

                Debug.Log("Movimento Passar Porta");
            }
            else
            {
                pinca = false;
                rotacionar = false;
                passarPorta = false;

                palmaDaMao = Vector2.zero;
                
                Debug.Log("Nenhum movimento Ativo");
            }
        }
    }
    private void CenterHand_PassarPorta()
    {
        if (passarPorta)
        {
            if (palmaDaMao == Vector2.zero)
            {
                if (handTracking.handPoints[9].transform.position.x >= -1.5f && handTracking.handPoints[9].transform.position.x <= 1.5f)
                {
                    palmaDaMao = handTracking.handPoints[9].transform.position;
                    palmaDaMaoDireito = new Vector2(palmaDaMao.x + 5.5f, palmaDaMao.y);
                    palmaDaMaoEsquerdo = new Vector2(palmaDaMao.x - 5.5f, palmaDaMao.y);
                }
            }
            else if (palmaDaMao != Vector2.zero)
            {
                if (Vector3.Distance(handTracking.handPoints[9].transform.position,palmaDaMaoDireito) <= 2.75f && MovPassarPorta >= 0)
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
                if (Vector3.Distance(handTracking.handPoints[9].transform.position, palmaDaMaoEsquerdo) <= 2.75f && MovPassarPorta <= 0)
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
