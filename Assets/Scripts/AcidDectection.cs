using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class AcidDectection : MonoBehaviour
{
    public GameObject sphere;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MoveControl")
        {
            Debug.Log("ALO");
            Destroy(other.gameObject);
            SpawnPoint.objectCreated = false;        
        }
    }

}
