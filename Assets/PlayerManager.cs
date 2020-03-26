using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float coolDown = 5;
    public float coolDownTimer;
    public float range = 100f;

    public GameObject bullet;

    private bool canUse;

    public Camera fpsCam;

    private void Start()
    {
        canUse = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if(coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetButtonDown("Fire1") && coolDownTimer == 0) 
        {
            Ability();
            coolDownTimer = coolDown;
        }
    }

    void Ability()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Controlable")
            {
         
                Debug.Log(hit.transform.name);
            }
          
        }
    }
}
