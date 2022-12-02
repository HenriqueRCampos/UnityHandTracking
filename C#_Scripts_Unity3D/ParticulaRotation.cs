using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaRotation : MonoBehaviour
{
    public Selection selection;
    public Transform midRotation;
    public List<GameObject> sphareObjects;
    private List<GameObject> portasList;

    void Start()
    {
        portasList = selection.porta;
    }

    void Update()
    {
        bool animationInicial = portasList[HandMoviments.ListaPortaIndex].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("inicial");
        bool animationSepararPeca = portasList[HandMoviments.ListaPortaIndex].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SepararPeca");
        if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == null && animationInicial)
        {
            sphareObjects[0].transform.RotateAround(midRotation.position, Vector3.up, 6f);
            sphareObjects[1].transform.RotateAround(midRotation.position, Vector3.down, 6f);
        }
        else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == null && animationSepararPeca)
        {
            sphareObjects[2].transform.RotateAround(midRotation.position, Vector3.up, 6f);
            sphareObjects[3].transform.RotateAround(midRotation.position, Vector3.down, 6f);
        }
    }
}