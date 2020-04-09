using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDecetion : MonoBehaviour
{
    public Material[] material;
    GameObject playerMove;
    Renderer rend;
    public bool objectCamera;
    public GameObject playerFpsCam;
    public bool animControl;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void Update()
    {
        if(UIManager.Instance.abilityPanel.activeSelf)
        {
            Debug.Log("GLOWING");
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[0];
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
                PlatformMove.canControl = true;
            }
            else if (!objectCamera && !animControl && !Spirit.isControlling)
            {
                playerFpsCam.SetActive(true);
                PlatformMove.canControl = true;
            }
            else if (!objectCamera && animControl && !Spirit.isControlling)
            {
                playerFpsCam.SetActive(true);
                ObjectAnimation.canUseAnim = true;
            }
        }
    }
}
