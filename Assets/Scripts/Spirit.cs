using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public float speed = 8f;
    public static bool isControlling;
    GameObject playerCamera;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            /*
            foreach (Transform child in transform)
            {
                if (child.tag == "MainCamera")
                    child.gameObject.SetActive(false);
            }
            */
            ShootSpirit.canUse = true;
            // playerCamera.SetActive(false);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Controlable")
        {
            isControlling = true;
        }
    }
}
