using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonType : MonoBehaviour
{
   
    Animator useButtonAnim;
    private int doorState;
    public Animator useConnectedAnim;
    public BoxCollider colliderDoors;

    public float secondsToWait;
    private float secondsToIdle = 1;

    private void Start()
    {
        useButtonAnim = GetComponent<Animator>();

    }
    public void UseButtonAnim()
    {
        doorState = 1;
        useButtonAnim.SetTrigger("ButtonOpen");
        useConnectedAnim.SetInteger("DoorState", 1);
        StartCoroutine("ButtonTimer");
        Debug.Log("Pressed");
        Debug.Log("doorState= " + doorState);
    }

    private IEnumerator ButtonTimer()
    {
        yield return new WaitForSeconds(secondsToWait);
        doorState = 2;
        useConnectedAnim.SetInteger("DoorState", 2);
      /*  yield return new WaitForSeconds(secondsToIdle);
        doorState = 0;
        useConnectedAnim.SetInteger("DoorsOpen", doorState);*/
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerPresent");
            StopCoroutine("ButtonTimer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("ButtonTimer");
        }
    }
    */
}
