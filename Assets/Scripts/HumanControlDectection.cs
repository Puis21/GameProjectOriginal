using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControlDectection : MonoBehaviour
{
    GameObject playerMove;
    GameObject humanMove;

    public bool objectCamera;
    public  GameObject humanCam;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
        humanMove = GameObject.FindGameObjectWithTag("Human");
        humanCam.SetActive(false);
        humanMove.GetComponent<MovementScript_2>().enabled = false;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.F))
        {
            humanMove.GetComponent<MovementScript_2>().enabled = false;
            playerMove.GetComponent<MovementScript>().enabled = true;
            Spirit.isControlling = false;
            ShootSpirit.camState = true;
            humanCam.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spirit")
        {
            if (!Spirit.isControlling)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                playerMove.GetComponent<MovementScript>().enabled = false;
                humanMove.GetComponent<MovementScript_2>().enabled = true;
                Spirit.isControlling = true;
                ShootSpirit.camState = false;
                humanCam.SetActive(true);
            }
        }
    }
}
