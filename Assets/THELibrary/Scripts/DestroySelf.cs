using Unity.VisualScripting;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public GameObject required;
    public GameObject self;
    void Update()
    {
        if(required){}
        else{Destroy(self);}
    }
}
