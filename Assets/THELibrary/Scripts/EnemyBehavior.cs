using System.Runtime.CompilerServices;
using THELibrary;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody forward;
    public Rigidbody left;
    public Rigidbody right;
    private string facing = "forward";
    private string wasFacing = "left";
    public Timer time;
    public bool seesPlayer;
    public Light eyes;
    public float timer;

    void Update()
    {
        timer = time.timeLeft;
        if(time.timeLeft < 0.0f)
        {
            if(facing == "forward" && wasFacing == "left")
            {
                rb.MoveRotation(right.rotation);
                facing = "right";
            }
            else if(facing == "forward" && wasFacing == "right")
            {
                rb.MoveRotation(left.rotation);
                facing = "left";
            }
            else if(facing == "left")
            {
                rb.MoveRotation(forward.rotation);
                wasFacing = "left";
                facing = "forward";
            }
            else if(facing == "right")
            {
                rb.MoveRotation(forward.rotation);
                wasFacing = "right";
                facing = "forward";
            }
            time.StartTimer();
        }
    }
}
