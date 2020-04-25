using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float lookSensitivity;
    [SerializeField] private float smoothing;
    [SerializeField] private int maxLookRotation;

    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;

    private void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        if(GameManager.canAct)
        {
            RotateCamera();
        }
    }

    private void RotateCamera()
    {
        Vector2 InputValues = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        InputValues = Vector2.Scale(InputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, InputValues.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, InputValues.y, 1f / smoothing);

        currentLookingPos += smoothedVelocity;

        currentLookingPos.y = Mathf.Clamp(currentLookingPos.y, -maxLookRotation, maxLookRotation);
        transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, player.transform.up);

    }
}