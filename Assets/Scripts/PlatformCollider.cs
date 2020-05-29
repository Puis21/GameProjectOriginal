using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public GameObject thePlatform;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = thePlatform.transform;
        }

        if (other.gameObject.tag == "MoveControl")
        {
            other.transform.parent = thePlatform.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }

        if (other.gameObject.tag == "MoveControl")
        {
            other.transform.parent = null;
        }
    }
}
