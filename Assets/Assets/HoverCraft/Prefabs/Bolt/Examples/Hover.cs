using UnityEngine;

public class HovercraftController : MonoBehaviour
{
    public float hoverHeight = 2f;
    public float hoverDamping = 5f;
    public float groundCheckDistance = 5f;
    public LayerMask groundMask;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        Hover();
    }

    void Hover()
    {
        RaycastHit hit;
        Vector3 hoverPosition = transform.position;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask))
        {
            float currentHeight = hit.distance;
            float targetHeight = hoverHeight;
            float heightDifference = targetHeight - currentHeight;

            Vector3 force = Vector3.up * heightDifference * hoverDamping;
            rb.AddForce(force, ForceMode.Acceleration);
        }
    }
}

