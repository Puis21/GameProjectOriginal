using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDecetion : MonoBehaviour
{

    GameObject playerMove;
    public bool objectCamera;
    public GameObject playerFpsCam;
    public bool animControl;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spirit")
        {
            if (objectCamera)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                playerMove.GetComponent<MovementScript>().enabled = false;
                PlatformMove.canControl = true;
            }
            else if (!objectCamera && !animControl)
            {
                playerFpsCam.SetActive(true);
                PlatformMove.canControl = true;
            }
            else if (!objectCamera && animControl)
            {
                playerFpsCam.SetActive(true);
                ObjectAnimation.canUseAnim = true;
            }
        }
    }
}
