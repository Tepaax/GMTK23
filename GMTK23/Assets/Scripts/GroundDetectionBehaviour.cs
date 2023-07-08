using UnityEngine;

public class GroundDetectionBehaviour : MonoBehaviour
{
    public Color groundColor;  // The color of the ground that should trigger the car to slow down
    public float slowDownFactor = 0.5f;  // The factor by which the car's speed should be reduced

    public Rigidbody carRigidbody;

    public bool test = false;
    public bool test1 = false;

    private void Start()
    {
       // carRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        test = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit);
        test1 = hit.collider.GetComponent<MeshRenderer>().material.color == groundColor;
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit1))
        {
            // Check if the ground color matches the specified color
            if (hit1.collider.GetComponent<Renderer>().material.color == groundColor)
            {
                // Slow down the car by reducing its velocity
                carRigidbody.velocity *= slowDownFactor;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down);
    }
}
