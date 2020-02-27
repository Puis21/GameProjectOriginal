using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public float mouseSensitivity = 5f;
    //public float smoothing = 2.0f;

    public Transform playerBody;

    float xRotation = 0f;

    //GameObject character;
   // Vector2 smoothV;
   // Vector2 mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        //character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("MouseX") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("MouseY") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
        /*
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(mouseSensitivity * smoothing, mouseSensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        playerBody.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, playerBody.transform.up);
        */

    }
}
