using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject objectInteract;
    // Start is called before the first frame update
    void Start()
    {
        objectInteract.SetActive(true);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MoveControl")
        {
            objectInteract.SetActive(false);
            Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MoveControl")
        {
            objectInteract.SetActive(true);
        }
    }
}
