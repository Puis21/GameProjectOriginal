using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public GameObject thePlatform;
    public CapsuleCollider thePlayer;
    private void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.parent = thePlatform.transform;
        Debug.Log("Platform");
    }

    private void OnTriggerExit(Collider other)
    {
        thePlayer.transform.parent = null;
        Debug.Log("Platform Exit");
    }
}
