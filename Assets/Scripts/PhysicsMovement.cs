using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float jumpRaycastDistance = 2f;
    public LayerMask jumpLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Movement(Vector3.right);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Movement(Vector3.left);
        }

        if (CanJump() && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Movement(Vector3 direction)
    {
        Vector3 finalVelocity = rb.velocity;

        finalVelocity += direction * speed;

        if (finalVelocity.x > speed)
        {
            finalVelocity.x = speed;
        }
        else if (finalVelocity.x < -speed)
        {
            finalVelocity.x = -speed;
        }

        rb.velocity = finalVelocity;
    }

    private void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up);
    }

    private bool CanJump()
    {
        RaycastHit hit; 
        bool result = Physics.Raycast(this.transform.position, Vector3.down, out hit, jumpRaycastDistance, jumpLayers);

        if (result == true)
            Debug.DrawRay(this.transform.position, hit.point - this.transform.position, Color.red);

        return result;
    }
}
