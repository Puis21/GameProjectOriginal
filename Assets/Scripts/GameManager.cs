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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    [HideInInspector] public int deathScientists;
    public bool canAct;

    // Start is called before the first frame update
    void Start()
    {
        canAct = false;
        deathScientists = 0;
    }
}
