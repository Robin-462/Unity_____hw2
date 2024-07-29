using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject laserPrefab;
    public float laserSpeed = 20f;
    public float laserLifetime = 2f;
    public Transform laserSpawnPoint;

    private Rigidbody hovercraftRb;

    void Start()
    {
        hovercraftRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        Vector3 laserSpawnPosition = laserSpawnPoint.position;
        Quaternion laserRotation = laserSpawnPoint.rotation;

        GameObject laser = Instantiate(laserPrefab, laserSpawnPosition, laserRotation);

        Rigidbody rb = laser.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = laserSpawnPoint.forward * laserSpeed;
        }
        else
        {
            Debug.LogError("Laser prefab is missing Rigidbody component.");
        }

        Destroy(laser, laserLifetime);
    }
}
