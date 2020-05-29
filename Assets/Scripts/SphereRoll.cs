using UnityEngine;
using System.Collections;

public class SphereRoll : MonoBehaviour
{

	public float walkSpeed;
	public float runSpeed;
	public float gravity;
	public float jumpHeight;
	[Range(0, 1)]
	public float airControlPercent;

	public float turnSmoothTime;
	float turnSmoothVelocity;

	public float speedSmoothTime;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	public static bool isControlled;

	Transform cameraT;
	CharacterController controller;

	void Start()
	{
		cameraT = GameObject.FindGameObjectWithTag("SecondCam").transform;
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		// input
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = Input.GetKey(KeyCode.LeftShift);

			Move(inputDir, running);

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
			// animator
			if (isControlled)
			{
				walkSpeed = 3f;
				jumpHeight = 1.5f;
			}
			else
			{
				walkSpeed = 0f;
				jumpHeight = 0f;
			}
		
	}

	void Move(Vector2 inputDir, bool running)
	{
		if (inputDir != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		}

		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

		if (controller.isGrounded)
		{
			velocityY = 0;
		}

	}

	void Jump()
	{
		if (controller.isGrounded)
		{
			float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
	}

	float GetModifiedSmoothTime(float smoothTime)
	{
		if (controller.isGrounded)
		{
			return smoothTime;
		}

		if (airControlPercent == 0)
		{
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}
}