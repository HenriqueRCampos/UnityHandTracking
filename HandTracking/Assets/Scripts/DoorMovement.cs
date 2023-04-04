using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public List<GameObject> doorParts;

    public void Selecionar(GameObject Selecionado)
    {
        for (int i = 0; i < doorParts.Count; i++)
        {
            if (Selecionado != null)
            {
                if (doorParts[i] == Selecionado)
                {
                    doorParts[i].SetActive(true);
                }
                else
                {
                    doorParts[i].SetActive(false);
                }
            }
            else
            {
                doorParts[i].SetActive(true);
            }
        }
    }   
}