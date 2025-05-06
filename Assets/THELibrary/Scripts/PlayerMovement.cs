using THELibrary;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform cameraBody;
    public float moveSpeed = 1000f;
    public float sprintSpeed = 2000f;
    public Timer jumpTimer;
    void Start()
    {
        rb.maxLinearVelocity = 1000;
    }
    void FixedUpdate()
    {
        transform.rotation = new Quaternion(rb.rotation.x, cameraBody.rotation.y,rb.rotation.z,cameraBody.rotation.w);
        if (Input.GetKey("w"))
        {
            rb.AddRelativeForce(0,0,moveSpeed*Time.deltaTime);
        }
        if( Input.GetKey("a"))
        {
            rb.AddRelativeForce(-moveSpeed*Time.deltaTime,0,0);
        }
        if( Input.GetKey("s"))
        {
            rb.AddRelativeForce(0,0,-moveSpeed*Time.deltaTime);
        }
        if( Input.GetKey("d"))
        {
            rb.AddRelativeForce(moveSpeed*Time.deltaTime,0,0);
        }
        if( Input.GetKey("space")&&jumpTimer.timeLeft <=0)
        {
            rb.AddForce(0,270,0);
            jumpTimer.StartTimer();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        jumpTimer.StopTimer();
    }
}
