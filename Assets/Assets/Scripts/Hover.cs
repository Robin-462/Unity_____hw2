using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float hoverHeight = 15f;
    public float hoverDamping = 5f;
    public float groundCheckDistance = 5f;
    public LayerMask groundMask;
    public float maxVerticalSpeed = 10f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
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

            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime *5f);
        }
        else
        {
            rb.AddForce(Vector3.down * 10f, ForceMode.Acceleration);
        }
    }
}