using UnityEngine;

public class HovercraftController_1 : MonoBehaviour
{
    public float force = 1000f; 
    public float torque = 500f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddRelativeForce(0, 0, force * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddRelativeForce(0, 0, -force * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            rb.AddRelativeTorque(0, -torque * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddRelativeTorque(0, torque * Time.deltaTime, 0);
    }
}
