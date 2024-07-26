using UnityEngine;

public class Hover : MonoBehaviour
{
    public float hoverHeight = 5.0f;
    public float hoverForce = 65.0f;
    public float damping = 0.5f;
    public LayerMask terrainLayer; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight * 2, terrainLayer))
        {
            float desiredHeight = hit.point.y + hoverHeight;
            float currentHeight = transform.position.y;
            float heightDifference = desiredHeight - currentHeight;

            float proportionalHeight = heightDifference / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            Vector3 dampingForce = -rb.velocity * damping;

            rb.AddForce(appliedHoverForce + dampingForce, ForceMode.Acceleration);
        }
    }
}

