﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectControl : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    GameObject playerMove;


    public bool objectCamera;

    public static bool objCamState;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        objCamState = false;
        SphereRoll.isControlled = false;
    }

    private void Update()
    {
        if (UIManager.Instance.abilityPanel.activeSelf)
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[0];
        }

        if (Input.GetKey(KeyCode.F))
        {
            playerMove.GetComponent<MovementScript>().enabled = true;
            SphereRoll.isControlled = false;
            Spirit.isControlling = false;
            objCamState = false;
            ShootSpirit.camState = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spirit")
        {
            if (!Spirit.isControlling)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                playerMove.GetComponent<MovementScript>().enabled = false;
                SphereRoll.isControlled = true;
                Spirit.isControlling = true;
                objCamState = true;
            }
        }
    }
}
