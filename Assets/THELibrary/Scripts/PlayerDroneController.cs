using UnityEngine;

public class PlayerDroneController : MonoBehaviour
{
    public Transform player;
    public float mouseX = 0f;
    public float mouseY = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePositionDelta.x;
        mouseY = Input.mousePositionDelta.y;
        transform.position = player.position;
        transform.eulerAngles += new Vector3(-mouseY/2, mouseX/2, 0);
    }
}
