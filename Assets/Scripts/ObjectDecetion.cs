using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDecetion : MonoBehaviour
{
    public Material[] material;
    GameObject playerMove;
    PlatformMove platformScript;
    Renderer rend;

    public bool objectCamera;
    public GameObject playerFpsCam;
    public bool animControl;

    public static bool canMovePlatform;
    public static bool canUseAnim;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
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
        Debug.Log(Spirit.isControlling);

        if (Input.GetKey(KeyCode.F))
        {
            platformScript.GetComponent<PlatformMove>().enabled = false;
            Spirit.isControlling = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spirit")
        {
            if (objectCamera && !Spirit.isControlling)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                playerMove.GetComponent<MovementScript>().enabled = false;
                Spirit.isControlling = true;
            }
            else if (!objectCamera && !animControl && !Spirit.isControlling)
            {
                playerFpsCam.SetActive(true);
                platformScript.GetComponent<PlatformMove>().enabled = true;
                Spirit.isControlling = true;
                
            }   
        }
    }
}
