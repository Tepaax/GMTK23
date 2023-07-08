using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool movingEnabled = false;

    private float currentSpeed = 0f;
    private float acceleration = 5f;

    public GameObject[] wheels;
    public float wheelRadius;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movingEnabled = true;
        }

        if (movingEnabled)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        transform.Translate(currentSpeed * Time.deltaTime * Vector3.forward);

        float distanceTraveled = currentSpeed * Time.deltaTime;
        float rotationInRadians = distanceTraveled / wheelRadius;
        float rotationInDegrees = rotationInRadians * Mathf.Rad2Deg;

        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(rotationInDegrees, 0, 0);
        }
    }
}
