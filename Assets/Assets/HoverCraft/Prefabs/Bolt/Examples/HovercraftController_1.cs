using UnityEngine;

public class HovercraftController_1 : MonoBehaviour
{
    public float force = 1000f;
    public float torque = 500f;
    public float hoverHeight = 15f;
    public float hoverDamping = 5f;
    public float groundCheckDistance = 5f;
    public LayerMask groundMask;
    public float maxVerticalSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        Hover();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.back * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.forward * force * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(Vector3.up * -torque * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(Vector3.up * torque * Time.deltaTime);
        }
    }

    void Hover()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask))
        {
            float currentHeight = hit.distance;
            float targetHeight = hoverHeight;
            float heightDifference = targetHeight - currentHeight;

            Vector3 force = Vector3.up * heightDifference * hoverDamping;

            if (rb.velocity.y > maxVerticalSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, maxVerticalSpeed, rb.velocity.z);
            }
            else if (rb.velocity.y < -maxVerticalSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, -maxVerticalSpeed, rb.velocity.z);
            }

            rb.AddForce(force, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(Vector3.down * 10f, ForceMode.Acceleration);
        }
    }
}
