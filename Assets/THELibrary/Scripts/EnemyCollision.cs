using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject self;
    public ParticleSystem particles;
    public string tagName;

    void OnCollisionEnter()
    {
        particles.Play();
        Destroy(self);
    } 
}
