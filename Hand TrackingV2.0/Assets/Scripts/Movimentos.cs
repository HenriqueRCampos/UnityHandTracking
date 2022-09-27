using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Movimentos : MonoBehaviour
{
    public HandTracking handTracking;
    public static bool pinca = false;
    public static bool rotacionar = false;
    public static bool desmontarPorta = false;

    void Start()
    {
    }


    void FixedUpdate()
    {
        if(!UDPReceiveRe.Igual1)
        MovimentoPinca();
    }

    void MovimentoPinca()
    {
        var dis_PolegarCenter = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[15].transform.position);
        var dis_IndicadorCenter = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[5].transform.position);
        var dis_DedoMeioCenter = Vector3.Distance(handTracking.handPoints[12].transform.position, handTracking.handPoints[9].transform.position);
        var dis_AnelarCenter = Vector3.Distance(handTracking.handPoints[16].transform.position, handTracking.handPoints[13].transform.position);
        var dis_MinguinhoCenter = Vector3.Distance(handTracking.handPoints[20].transform.position, handTracking.handPoints[17].transform.position);

        if (!rotacionar && !UDPReceiveRe.Igual1)
        {
  
            if (dis_MinguinhoCenter <= 0.89f && dis_AnelarCenter <= 0.89f && dis_DedoMeioCenter <= 0.89f && dis_PolegarCenter >= 0.6f && dis_IndicadorCenter >= 0.55f)
            {
                pinca = true;
                rotacionar = false;
            }
            else
            {
                pinca = false;
            }
        }
        MovimentoRotacao();
    }
    void MovimentoRotacao()
    {
      /*  var dis_PolegarCenter1 = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[15].transform.position);
        var dis_IndicadorCenter1 = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[5].transform.position);
        var dis_DedoMeioCenter1 = Vector3.Distance(handTracking.handPoints[0].transform.position, handTracking.handPoints[9].transform.position);
        var dis_AnelarCenter1 = Vector3.Distance(handTracking.handPoints[0].transform.position, handTracking.handPoints[13].transform.position);
        var dis_MinguinhoCenter1 = Vector3.Distance(handTracking.handPoints[0].transform.position, handTracking.handPoints[17].transform.position);*/
        var dis_PolegarCenter1 = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[15].transform.position);
        var dis_IndicadorCenter1 = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[5].transform.position);
        var dis_DedoMeioCenter1 = Vector3.Distance(handTracking.handPoints[12].transform.position, handTracking.handPoints[9].transform.position);
        var dis_AnelarCenter1 = Vector3.Distance(handTracking.handPoints[16].transform.position, handTracking.handPoints[13].transform.position);
        var dis_MinguinhoCenter1 = Vector3.Distance(handTracking.handPoints[20].transform.position, handTracking.handPoints[17].transform.position);
        if (!pinca && !UDPReceiveRe.Igual1)
        {
            if (dis_MinguinhoCenter1 <= 0.89f && dis_AnelarCenter1 <= 0.89f && dis_DedoMeioCenter1 <= 0.89f && dis_PolegarCenter1 < 0.6f && dis_IndicadorCenter1 < 0.55f )
            {
                {
                    rotacionar = true;
                    pinca = false;

                }
            }
            else
            {
                rotacionar = false;
            }
        }
        MovimentoDesmontar();
    }
    void MovimentoDesmontar()
    {
        var dis_IndicadorCenter2 = Vector3.Distance(handTracking.handPoints[8].transform.position, handTracking.handPoints[5].transform.position);
        var dis_DedoMeioCenter2 = Vector3.Distance(handTracking.handPoints[12].transform.position, handTracking.handPoints[9].transform.position);
        var dis_AnelarCenter2 = Vector3.Distance(handTracking.handPoints[16].transform.position, handTracking.handPoints[13].transform.position);
        var dis_MinguinhoCenter2 = Vector3.Distance(handTracking.handPoints[20].transform.position, handTracking.handPoints[17].transform.position);


        var dis_PolegarDedoMeio2 = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[12].transform.position);
        var dis_PolegarMinguinho2 = Vector3.Distance(handTracking.handPoints[4].transform.position, handTracking.handPoints[20].transform.position);

        if (!pinca && !rotacionar && !UDPReceiveRe.Igual1)
        {
            if (!desmontarPorta)
            {
                if (dis_IndicadorCenter2 >= 0.9f && dis_AnelarCenter2 >= 0.9f && dis_MinguinhoCenter2 >= 0.9f && dis_PolegarDedoMeio2 < 0.5f)
                {
                    desmontarPorta = true;
                    pinca = false;
                    rotacionar = false;
                }
            }
            if (desmontarPorta)
            {
                if (dis_IndicadorCenter2 >= 0.9f && dis_DedoMeioCenter2 >= 0.9f && dis_AnelarCenter2 >= 0.9f && dis_PolegarMinguinho2 < 0.5f)
                {
                    desmontarPorta = false;
                    pinca = false;
                    rotacionar = false;
                }
            }
        }
    }
}





/*
if (dis_PolegarIndicador2 <= 0.45f && dis_PolegarDedoMeio2 <= 0.45f && dis_PolegarAnelar2 <= 0.45f && dis_PolegarMinguinho2 <= 0.45f)
{
    desmontarPortaaux = true;
    if (desmontarPortaaux)
    {
        desmontarPorta = false;
    }
    pinca = false;
    rotacionar = false;
}
if (desmontarPortaaux)
{
    if (dis_PolegarIndicador2 >= 0.8f && dis_PolegarDedoMeio2 >= 0.8f && dis_PolegarAnelar2 >= 0.8f && dis_PolegarMinguinho2 >= 0.8f)
    {
        desmontarPorta = true;
        pinca = false;
        desmontarPortaaux = false;
        rotacionar = false;

    }
}
*/