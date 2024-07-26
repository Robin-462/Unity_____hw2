using UnityEngine;

public class HovercraftController_2 : MonoBehaviour
{
    public float force = 2000f;
    public float torque = 250f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
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
}
