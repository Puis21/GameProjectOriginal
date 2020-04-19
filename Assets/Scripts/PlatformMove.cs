using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    Rigidbody rbComponent;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rbComponent = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
   
            FullControlPlatform();
       
    }

    void HorizontalPlatform()
    {
        float strafe = Input.GetAxis("Horizontal2") * speed;
        strafe *= Time.deltaTime;
        transform.Translate(strafe, 0, 0);
    }


    void VerticalPlatform()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
    }

    void FullControlPlatform()
    {
        float translation = Input.GetAxis("Vertical2") * speed;
        float strafe = Input.GetAxis("Horizontal2") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        transform.Translate(strafe, 0, translation);
    }

}
