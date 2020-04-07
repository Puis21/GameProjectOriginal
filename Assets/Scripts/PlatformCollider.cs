using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public GameObject thePlatform;
    public GameObject thePlayer;
    private void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.parent = thePlatform.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        thePlayer.transform.parent = null;
    }
}
