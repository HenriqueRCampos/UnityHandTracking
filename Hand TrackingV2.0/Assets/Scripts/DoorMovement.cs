using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{

    public List<GameObject> Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Selecionar(GameObject Selecionado)
    {
        for (int i = 0; i < Door.Count; i++)
        {
            if (Selecionado != null)
            {
                if (Door[i] == Selecionado)
                {
                    Door[i].SetActive(true);
                }
                else
                {
                    Door[i].SetActive(false);
                }
            }
            else
            {
                Door[i].SetActive(true);
            }
        }
    }
}
