using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{

    RaycastHit hit;

    [SerializeField] private float range;

    private bool canShoot;

    public GameObject thisWeapon;
    public GameObject humanGun;
    public GameObject bulletGun;
    public GameObject door;
    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        humanGun.SetActive(false);
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.tag == "Gun")
            {
                UIManager.Instance.interactText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    humanGun.SetActive(true);
                    thisWeapon.SetActive(false);
                    canShoot = true;
                }
            }
            else
            {
                UIManager.Instance.interactText.SetActive(false);
            }

            if (hit.collider.tag == "Button")
            {
                UIManager.Instance.interactText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.SetActive(false);
                }
            }
            else
            {
                UIManager.Instance.interactText.SetActive(false);
            }

        }
        if(canShoot && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletGun);
        bulletObject.transform.position = fpsCam.transform.position + transform.forward;
        bulletObject.transform.forward = fpsCam.transform.forward;
    }
}
