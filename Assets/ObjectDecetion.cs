using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDecetion : MonoBehaviour
{

    GameObject playerMove;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spirit")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            playerMove.GetComponent<MovementScript>().enabled = false;
            Debug.Log("MeHIt");
        }
    }
}
