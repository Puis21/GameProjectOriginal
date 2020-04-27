using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public float speed;
    public static bool isControlling;
    public static bool isAlive;

    private void Start()
    {
        isAlive = true;
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Glass" )
        {
            isAlive = false;
            ShootSpirit.canUse = true;
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Controlable" || other.gameObject.tag == "Untagged")
        {
            ShootSpirit.camState = true;
        }
    }
}
