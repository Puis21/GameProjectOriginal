using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDecetion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spirit")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("MeHIt");
        }
    }
}
