using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript_2 : MonoBehaviour
{

    // public CharacterController controller;
    Rigidbody playerRb;
    Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

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

            float translation = Input.GetAxis("Vertical");
            float strafe = Input.GetAxis("Horizontal");


            playerRb.transform.Translate(strafe * speed * Time.deltaTime, 0, translation * speed * Time.deltaTime);
            anim.SetFloat("Vertical", translation);
            anim.SetFloat("Horizontal", strafe);


            if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("jumped", true);
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
            else
            {
                anim.SetBool("jumped", false);
            }

            if (isGrounded())
            {
                speed = 3.0f;

            }
    }

    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius * 1f, groundLayers);
    }
}
