using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject objectPrefab;

    private Transform objPosition;
    public static bool objectCreated;
    // Start is called before the first frame update
    void Start()
    {
        objectCreated = false;
        objPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!objectCreated)
        {
            GameObject objectSpawn = Instantiate(objectPrefab);
            objectSpawn.transform.position = objPosition.transform.position;
            objectCreated = true;
        }
    }
}
