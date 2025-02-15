﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDecetion : MonoBehaviour
{
    public Material[] material;
    PlatformMove platformScript;
    Renderer rend;

    public bool objectCamera;
    public GameObject playerFpsCam;

    public static bool canUseAnim;

    private void Start()
    {
        platformScript = GetComponent<PlatformMove>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void Update()
    {
        if(UIManager.Instance.abilityPanel.activeSelf)
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[0];
        }

        if (Input.GetKey(KeyCode.F))
        {
            platformScript.GetComponent<PlatformMove>().enabled = false;
            Spirit.isControlling = false;
            UIManager.Instance.platformPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spirit")
        {
             if (!Spirit.isControlling)
            {
                playerFpsCam.SetActive(true);
                platformScript.GetComponent<PlatformMove>().enabled = true;
                Spirit.isControlling = true;
                UIManager.Instance.platformPanel.SetActive(true);
            }   
        }
    }
}
