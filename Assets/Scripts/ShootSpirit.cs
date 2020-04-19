using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpirit : MonoBehaviour
{
    public ButtonType buttonUse;
    RaycastHit hit;

    public SlowMotion TimeManager;
    public GameObject bullet;



    [SerializeField] private float range;
    public static bool canUse;
    public static bool slowActive;

    public Camera fpsCam;
    
    private void Start()
    {
        canUse = true;
        slowActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && !Spirit.isControlling)
        {
            UIManager.Instance.abilityPanel.SetActive(true);
            TimeManager.DoSlowMotion();

            if (Input.GetButtonDown("Fire1") && canUse)
            {
                Ability();
                fpsCam.gameObject.SetActive(false);
                // canUse = false;                   

            }
        }
        else
        {
            UIManager.Instance.abilityPanel.SetActive(false);
            TimeManager.DoSpeedUp();
        }


        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.green);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.tag == "Button")
            {
                UIManager.Instance.interactText.SetActive(true);
               
                if (Input.GetKey(KeyCode.E))
                {
                    buttonUse.UseButtonAnim();
                }
            }
            else
            {
                UIManager.Instance.interactText.SetActive(false);
            }

                
        }

    }

    void Ability()
    {
        GameObject bulletObject = Instantiate(bullet);
        bulletObject.transform.position = fpsCam.transform.position;
        bulletObject.transform.forward = fpsCam.transform.forward;

    }
}

