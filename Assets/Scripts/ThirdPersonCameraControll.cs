using UnityEngine;
using System.Collections;

public class ThirdPersonCameraControll : MonoBehaviour
{

	public float mouseSensitivity = 10;
	public Transform target;
	public float dstFromTarget = 2;
	public Vector2 pitchMinMax = new Vector2(-40, 85);

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	private Camera objCam;
	private AudioListener objAudio;

	float yaw;
	float pitch;

	void Start()
	{
		objCam = GetComponent<Camera>();
		objCam.enabled = false;
		objAudio = GetComponent<AudioListener>();
		objAudio.enabled = false;
	}

	private void Update()
	{
		if(ObjectDetectControl.objCamState)
		{
			objCam.enabled = true;
			objAudio.enabled = true;
		}
		else
		{
			objCam.enabled = false;
			objAudio.enabled = false;
		}
	}

	void LateUpdate()
	{
		if (GameManager.Instance.canAct)
		{
			yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
			pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
			pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

			currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
			transform.eulerAngles = currentRotation;

			transform.position = target.position - transform.forward * dstFromTarget;
		}
	}

}