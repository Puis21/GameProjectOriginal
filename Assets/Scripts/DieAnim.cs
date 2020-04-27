using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnim : MonoBehaviour
{

    Animator anim;
    CapsuleCollider colliderCap;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        colliderCap = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            anim.SetTrigger("Shot");
            GameManager.Instance.deathScientists += 1;
            StartCoroutine(GoDown());
        }
    }

    private IEnumerator GoDown()
    {
        yield return new WaitForSeconds(1f);
        colliderCap.direction = 2;
    }
}
