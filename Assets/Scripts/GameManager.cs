using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform lastCheckPointPos;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public Animator startAnim;
    public static bool canAct;

    // Start is called before the first frame update
    void Start()
    {
        startAnim.SetTrigger("LiftGoUp");
        canAct = false;
        StartCoroutine(CanAct());

    }

    private IEnumerator CanAct()
    {
        yield return new WaitForSeconds(0f);
        canAct = true;
    }
}
