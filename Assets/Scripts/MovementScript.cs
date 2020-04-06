using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    // public CharacterController controller;
    Rigidbody playerRb;
    Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool isWalkingFront;
    private bool isWalkingRight;
    private bool isWalkingLeft;
    private bool isWalkingBack;

    public LayerMask groundLayers;

    public CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        */
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        anim.SetBool("walkingFront", isWalkingFront);
        anim.SetBool("walkingRight", isWalkingRight);
        anim.SetBool("walkingLeft", isWalkingLeft);
        anim.SetBool("walkingBack", isWalkingBack);

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(isGrounded())
        {
            speed = 3.0f;
        }
      /*  else if(!isGrounded())
        {
            speed = 1.5f;
        }*/

        if (playerRb.velocity.magnitude > 0 && Input.GetKey(KeyCode.W) && isGrounded())
        {
            isWalkingFront = true;
            isWalkingLeft = false;
            isWalkingRight = false;
            isWalkingBack = false;
        }
        else if (playerRb.velocity.magnitude > 0 && Input.GetKey(KeyCode.D) && isGrounded())
        {
            isWalkingRight = true;
            isWalkingLeft = false;
            isWalkingFront = false;
            isWalkingBack = false;
        }
        else if (playerRb.velocity.magnitude > 0 && Input.GetKey(KeyCode.A) && isGrounded())
        {
            isWalkingLeft = true;
            isWalkingFront = false;
            isWalkingRight = false;
            isWalkingBack = false;
        }
        else if (playerRb.velocity.magnitude > 0 && Input.GetKey(KeyCode.S) && isGrounded())
        {
            isWalkingBack = true;
            isWalkingLeft = false;
            isWalkingFront = false;
            isWalkingRight = false;
        }
        else
        {
            isWalkingFront = false;
            isWalkingRight = false;
            isWalkingLeft = false;
            isWalkingBack = false;

        }


    
    }

    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius * 1f, groundLayers);
    }
}
