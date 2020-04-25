using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDecetAnim : MonoBehaviour
{
    public Material[] material;
    GameObject playerMove;
    ObjectAnimation animScript;
    Renderer rend;

    public bool objectCamera;
    public GameObject playerFpsCam;
    public bool animControl;

    public static bool canUseAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player");
        animScript = GetComponent<ObjectAnimation>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.abilityPanel.activeSelf)
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[0];
        }

        if (Input.GetKey(KeyCode.F))
        {
            animScript.GetComponent<ObjectAnimation>().enabled = false;
            Spirit.isControlling = false;
            UIManager.Instance.animPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spirit")
        {
            if (!objectCamera && animControl && !Spirit.isControlling)
            {
                playerFpsCam.SetActive(true);
                animScript.GetComponent<ObjectAnimation>().enabled = true;
                Spirit.isControlling = true;
                UIManager.Instance.animPanel.SetActive(true);
            }
        }
    }
}
