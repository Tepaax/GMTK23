using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody = null;
    private bool movingEnabled = false;
    float currentSpeed = 0f;
    float acceleration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            currentSpeed -= acceleration * Time.deltaTime * 0.5f;
        }

        transform.Translate(currentSpeed * Time.deltaTime * Vector3.forward);
    }
}
