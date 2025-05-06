using UnityEngine;
using THELibrary;

public class EnemyDetection : MonoBehaviour
{
    public float radius = 30f;
    public float angle = 45f;
    public LayerMask detectionLayer;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, detectionLayer);

        foreach (Collider hit in hits)
        {
            Vector3 directionToTarget = (hit.transform.position - transform.position).normalized;

            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget <= angle)
            {
                Ray ray = new Ray(transform.position, directionToTarget);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, radius, detectionLayer))
                {
                    if (hitInfo.collider.name == "Player")
                    {
                        Destroy(hit.gameObject);
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualization: draw the detection radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        // Draw field of view limits
        Vector3 leftBoundary = Quaternion.Euler(0, -angle, 0) * transform.forward * radius;
        Vector3 rightBoundary = Quaternion.Euler(0, angle, 0) * transform.forward * radius;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}