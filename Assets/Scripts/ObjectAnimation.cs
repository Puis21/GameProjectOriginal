using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
    public Animator anim;

    private bool useAnim;

    public static bool canUseAnim;
    // Start is called before the first frame update
    void Start()
    {
        canUseAnim = false;
        useAnim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUseAnim && Input.GetKeyDown(KeyCode.V) && !useAnim)
        {
            useAnim = true;
            anim.SetBool("animUsed", useAnim);
        }
        else if(canUseAnim && Input.GetKeyDown(KeyCode.V) && useAnim)
        {
            useAnim = false;
            anim.SetBool("animUsed", useAnim);
        }


        Debug.Log("useAnim:" + useAnim);
        Debug.Log("canUseAnim:" + canUseAnim);

    }
}
