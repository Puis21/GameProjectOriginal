using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject cam;

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            cam.SetActive(true);
        }
    }
}
