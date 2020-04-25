using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
    public Animator anim;

    private bool useAnim;

    // Start is called before the first frame update
    void Start()
    {
        useAnim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.canAct)
        {
            if (Input.GetKeyDown(KeyCode.V) && !useAnim)
            {
                useAnim = true;
                anim.SetBool("animUsed", useAnim);
                Debug.Log("UsedAnim");
            }
            else if (Input.GetKeyDown(KeyCode.V) && useAnim)
            {
                useAnim = false;
                anim.SetBool("animUsed", useAnim);
            }
        }
    }
}
