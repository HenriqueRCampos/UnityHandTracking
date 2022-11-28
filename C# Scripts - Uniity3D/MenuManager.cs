using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private Animator introCameraAnimator;
    public GameObject introCamera;
    public GameObject mainCamera;
    public GameObject backGroundMenu;
    public GameObject buttonVoltarSeleção;
    public GameObject buttonMenu;
    public GameObject circleTimer;               
    public Animator guiaMovimentsAnimator;               
    public GameObject guiaMoviments;               
    public GameObject guiaButtonOn;                             
    public GameObject guiaButtonOff;               
    public List<GameObject> messagesUI;
    private GameObject doorNameUI;

    float timer = 0f;
    bool inicialState = false;
    bool gameStart = false;
   

    private void Start()
    {
        doorNameUI = GameObject.FindWithTag("CanvasDoorUI");
        doorNameUI.SetActive(false);
        guiaMoviments.SetActive(false);
        guiaButtonOn.SetActive(false);
        guiaButtonOff.SetActive(false);
        circleTimer.SetActive(false);
        backGroundMenu.SetActive(true);
        introCameraAnimator = introCamera.GetComponent<Animator>();
        buttonMenu.SetActive(false);
        buttonVoltarSeleção.SetActive(false);
        introCameraAnimator.SetBool("iniciarIntro", true);
        mainCamera.SetActive(false);
    }
    private void Update()
    {
        if (!gameStart)
        {
            timer += Time.deltaTime;
            if (timer >= 81 && timer < 82)
            {
                introCameraAnimator.SetBool("iniciarIntro", false);
                introCamera.SetActive(false);
                introCamera.transform.position = new Vector3(0.256f, 3.677f, -15.937f);
                introCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (timer >= 82)
            {
                MenuReload();
            }
        }       
        if (guiaMovimentsAnimator.GetCurrentAnimatorStateInfo(0).IsName("start") && inicialState)
        {
            guiaMoviments.SetActive(false);           
        }       
    }
    public void StartPormadeVRscene()
    {
        timer = 0f;
        gameStart = true;
        guiaButtonOn.SetActive(false);
        doorNameUI.SetActive(true);
        guiaButtonOff.SetActive(true);
        circleTimer.SetActive(true);
        backGroundMenu.SetActive(false);
        buttonMenu.SetActive(true);   
        introCameraAnimator.SetBool("iniciarIntro", false);
        introCamera.SetActive(false);
        mainCamera.SetActive(true);
        introCamera.transform.position = new Vector3(0.256f, 3.677f, -15.937f);
        introCamera.transform.rotation = new Quaternion(0, 0, 0,0);
    }

    public void MenuReload()
    {
        timer = 0f;
        gameStart = false;
        guiaMoviments.SetActive(false);
        guiaButtonOn.SetActive(false);
        guiaButtonOff.SetActive(false);
        doorNameUI.SetActive(false);
        HideUImessages();
        circleTimer.SetActive(false);
        backGroundMenu.SetActive(true);
        buttonMenu.SetActive(false);
        introCamera.SetActive(true);
        mainCamera.SetActive(false);
        introCameraAnimator.SetBool("iniciarIntro", true);      
    }

    private void HideUImessages()
    {
        for (int i = 0; i < messagesUI.Count; i++)
        {
            messagesUI[i].SetActive(false);
        }
    }

    public void ShowGuideMoviments()
    {
        inicialState = false;
        guiaMoviments.SetActive(true);
        guiaButtonOff.SetActive(false);
        guiaButtonOn.SetActive(true);
        guiaMovimentsAnimator.SetBool("guideShow", true);
        guiaMovimentsAnimator.SetBool("guideHide", false);
    }

    public void HideGuideMoviments()
    {
        inicialState = true;
        guiaButtonOff.SetActive(true);
        guiaButtonOn.SetActive(false);
        guiaMovimentsAnimator.SetBool("guideHide", true);
        guiaMovimentsAnimator.SetBool("guideShow", false);
    }
    
}
