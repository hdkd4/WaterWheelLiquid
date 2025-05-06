using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.rotation = player.rotation;
        transform.position = player.position - transform.forward*4;
    }
}
