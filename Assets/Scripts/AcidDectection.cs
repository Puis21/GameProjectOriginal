using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcidDectection : MonoBehaviour
{
    GameObject playerMove;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
    }

        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MoveControl")
        {
            Destroy(other.gameObject);
            SpawnPoint.objectCreated = false;
            ShootSpirit.camState = true;
            playerMove.GetComponent<MovementScript>().enabled = true;
            SphereRoll.isControlled = false;
            Spirit.isControlling = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = GameManager.Instance.lastCheckPointPos.position;
        }
    }

}
