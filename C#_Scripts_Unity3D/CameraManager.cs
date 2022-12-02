using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public HandTracking handTracking;
    public DoorMovement doorMovement;
    public Selection selection;
    public Camera main;
    public Transform midCamera;
    public List<Transform> midsDoorParts;
    public float turnSpeed = 0.1f;
    public Quaternion rotGoal;
    private GameObject doorNameUI;

    void Update()
    {
        if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == null)
        {
            rotGoal = Quaternion.LookRotation((midCamera.position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midCamera.position, Vector3.Lerp(Vector3.up, Vector3.down, HandMoviments.turnRotation), 1.00f);

        }else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == GameObject.FindWithTag("alizar"))
        {
            rotGoal = Quaternion.LookRotation((midsDoorParts[0].position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midsDoorParts[0].position, Vector3.up, 1.00f);
        }
        else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == GameObject.FindWithTag("alizar2"))
        {
            rotGoal = Quaternion.LookRotation((midsDoorParts[1].position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midsDoorParts[1].position, Vector3.up, 1.00f);
        }
        else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == GameObject.FindWithTag("folha"))
        {
            rotGoal = Quaternion.LookRotation((midsDoorParts[2].position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midsDoorParts[2].position, Vector3.up, 1.00f);
        }
        else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == GameObject.FindWithTag("folha2"))
        {
            rotGoal = Quaternion.LookRotation((midsDoorParts[3].position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midsDoorParts[3].position, Vector3.up, 1.00f);
        }
        else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == GameObject.FindWithTag("macaneta"))
        {
            rotGoal = Quaternion.LookRotation((midsDoorParts[4].position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midsDoorParts[4].position, Vector3.up, 1.00f);
        }
        else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == GameObject.FindWithTag("marco"))
        {
            rotGoal = Quaternion.LookRotation((midsDoorParts[5].position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midsDoorParts[5].position, Vector3.up, 1.00f);
        }
        else if (HandMoviments.rotacionar && UDPReceiveRe.handInScreen && selection.Selecionado == GameObject.FindWithTag("recheio"))
        {
            rotGoal = Quaternion.LookRotation((midsDoorParts[6].position - transform.position).normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
            transform.RotateAround(midsDoorParts[6].position, Vector3.up, 1.00f);
        }
        doorNameUI = GameObject.FindWithTag("CanvasDoorUI");
        doorNameUI.transform.LookAt(main.transform.position);      
    }
}