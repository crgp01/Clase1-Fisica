using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
      
{
    private Rigidbody rb;
    private bool jumpInput;
    private bool onGround;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
        }
    }

    // Rigid body movement excecuted in fixedupdate
    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 movement = (Vector3.forward * verticalAxis + Vector3.right * horizontalAxis).normalized;
        rb.velocity = movement * 5 + Vector3.up * rb.velocity.y;

        //transform.position += movement * 5 * Time.deltaTime;

        if (jumpInput && OnGround()) {
            rb.velocity = Vector3.up * 5;
            if (jumpInput && !OnGround())
            {
                rb.velocity = Vector3.up * 5;
            }
            jumpInput = false;
        }
      
    }

    /*private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Ground") {
             onGround = true;
         }
     }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            onGround = false;
        }
    }*/

    private bool OnGround() {

        Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.black, 3);
        return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    }
    private bool OnSky()
    {

        Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.black, 3);
        return Physics.Raycast(transform.position, Vector3.up, 1.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * 1.5f);
   
    }
   

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = false;
        }

    }*/
}
