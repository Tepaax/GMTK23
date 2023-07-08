using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_TextMeshPro = null;

    public bool movingEnabled = false;
    public float wheelRadius = 1.0f;

    private float currentSpeed = 0.0f;
    private float acceleration = 5.0f;

    private float timer;

    // private GameObject[] wheels = null;
    private GameObject selectedCar = null;

    void Start()
    {
        if (PlayerPrefs.HasKey("car"))
        {
            selectedCar = Instantiate(Resources.Load<GameObject>("FBX_Models/" + PlayerPrefs.GetString("car")), transform.position, transform.rotation, transform);
        }
        else
        {

            selectedCar = Instantiate(Resources.Load<GameObject>("FBX_Models/truck"), transform.position, transform.rotation, transform);
        }

        // wheels = new GameObject[4];
        //for (int i = 0; i < wheels.Length; i++)
        //{
        //    wheels[i] = selectedCar.transform.GetChild(i + 1).gameObject;
        //}
    }
    public void ReinstantiateCar()
    {
        if (PlayerPrefs.HasKey("car"))
        {
            Destroy(selectedCar);
            selectedCar = Instantiate(Resources.Load<GameObject>("FBX_Models/" + PlayerPrefs.GetString("car")), transform.position, transform.rotation, transform);
            //  Array.Clear(wheels, 0, wheels.Length);
            //for (int i = 0; i < wheels.Length; i++)
            //{
            //    wheels[i] = selectedCar.transform.GetChild(i + 1).gameObject;
            //}

        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        DisplayTime();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movingEnabled = true;
        }

        if (movingEnabled)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        transform.Translate(currentSpeed * Time.deltaTime * Vector3.forward);

        //float distanceTraveled = currentSpeed * Time.deltaTime;
        //float rotationInRadians = distanceTraveled / wheelRadius;
        //float rotationInDegrees = rotationInRadians * Mathf.Rad2Deg;

        //foreach (GameObject wheel in wheels)
        //{
        //    wheel.transform.Rotate(rotationInDegrees, 0, 0);
        //}
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        int milliseconds = Mathf.FloorToInt((timer * 1000) % 1000);
        string timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        m_TextMeshPro.SetText("Timer: " + timeString);
    }
}
