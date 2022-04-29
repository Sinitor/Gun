using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyMove : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private bool isGround;

    [SerializeField] protected float speed = 5;
    [SerializeField] protected Vector3 movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        movement = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            Debug.Log("IsJump");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            Debug.Log("NotJump");
        }
    }
}