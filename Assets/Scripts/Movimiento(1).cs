using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private float rotationSpeed = 720f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [SerializeField] private MainShipHealth health;
    // Start is called before the first frame update
    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (health == null)
        {
            health = GetComponent<MainShipHealth>();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!health.IsDead())
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(0f, vertical, horizontal);

        float PosZ = Mathf.Clamp(transform.position.z, xMin, xMax);
        float PosY = Mathf.Clamp(transform.position.y, yMin, yMax);

        Vector3 clampedPosition = new Vector3(transform.position.x, PosY, PosZ);

        rb.MovePosition(clampedPosition + dir * speed * Time.deltaTime);

        if (vertical != 0)
        {
            rb.MoveRotation(transform.rotation * Quaternion.Euler(0f, 0f, vertical * rotationSpeed * Time.deltaTime));
        }
        else
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 0f, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(Quaternion.Euler(0f, 0f, angle));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector3(0f, 0f, xMin), new Vector3(5f, 5f, 5f));
        Gizmos.DrawCube(new Vector3(0f, 0f, xMax), new Vector3(5f, 5f, 5f));
        Gizmos.DrawCube(new Vector3(0f, yMin, 0f), new Vector3(5f, 5f, 5f));
        Gizmos.DrawCube(new Vector3(0f, yMax, 0f), new Vector3(5f, 5f, 5f));
    }
}
