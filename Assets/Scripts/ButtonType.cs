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
        useButtonAnim.SetTrigger("ButtonOpen");
        useConnectedAnim.SetInteger("DoorState", 1);
        StartCoroutine("ButtonTimer");
    }

    private IEnumerator ButtonTimer()
    {
        yield return new WaitForSeconds(secondsToWait);
        useConnectedAnim.SetInteger("DoorState", 2);
    }
}
