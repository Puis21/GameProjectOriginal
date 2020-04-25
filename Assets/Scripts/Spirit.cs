using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public float speed = 8f;
    public static bool isControlling;
    public static bool isAlive;

    private void Start()
    {
        isAlive = true;
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Debug.Log(isAlive);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Glass")
        {
            /*
            foreach (Transform child in transform)
            {
                if (child.tag == "MainCamera")
                    child.gameObject.SetActive(false);
            }
            */
            isAlive = false;
            ShootSpirit.canUse = true;
            ShootSpirit.camState = true;
            Destroy(gameObject);
        }
    }
}
