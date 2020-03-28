using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLook : MonoBehaviour
{
	[SerializeField] Vector3 cameraOffset;
	[SerializeField] float damping;

	Transform cameraTarget;
	CubeRoll cube;

	private void Update()
	{
		Vector3 targetposition = cameraTarget.position + cube.transform.forward * cameraOffset.z + cube.transform.up * cameraOffset.y +
			cube.transform.right * cameraOffset.x;

		Quaternion targetRotation = Quaternion.LookRotation(cameraTarget.position - targetposition, Vector3.up);

		transform.position = Vector3.Lerp(transform.position, targetposition, damping * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
	}

}