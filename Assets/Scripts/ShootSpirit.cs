using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpirit : MonoBehaviour
{
    ButtonType buttonUse;
    RaycastHit hit;

    public SlowMotion TimeManager;
    public GameObject bullet;



    [SerializeField] private float range;
    public static bool canUse;
    public static bool slowActive;
    public static bool camState;

    public Camera fpsCam;

    private void Start()
    {
        canUse = true;
        slowActive = false;
        camState = true;
        buttonUse = FindObjectOfType<ButtonType>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.canAct)
        {
            if (Input.GetKey(KeyCode.LeftShift) && !Spirit.isControlling && !Spirit.isAlive)
            {
                UIManager.Instance.abilityPanel.SetActive(true);
                TimeManager.DoSlowMotion();

                if (Input.GetButtonDown("Fire1") && canUse)
                {
                    Ability();
                    camState = false;
                    // canUse = false;                   

                }
            }
            else
            {
                UIManager.Instance.abilityPanel.SetActive(false);
                TimeManager.DoSpeedUp();
            }

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
            if (camState)
            {
                fpsCam.gameObject.SetActive(true);
            }
            else
            {
                fpsCam.gameObject.SetActive(false);
            }
    }

    void Ability()
    {
        GameObject bulletObject = Instantiate(bullet);
        bulletObject.transform.position = fpsCam.transform.position + transform.forward;
        bulletObject.transform.forward = fpsCam.transform.forward;

    }
}

