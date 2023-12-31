using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText = null;

    public bool movingEnabled = false;
    public float wheelRadius = 1.0f;

    private float currentSpeed = 0.0f;
    private float acceleration = 5.0f;

    private float timer;

    private GameObject selectedCar = null;

    [SerializeField]
    private float DownForceValue = 10.0f;
    private Rigidbody rb;
    [SerializeField]
    private GameObject ShowInfoScreen = null;

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
        rb = GetComponent<Rigidbody>();
    }

    public void ReinstantiateCar()
    {
        if (PlayerPrefs.HasKey("car"))
        {
            Destroy(selectedCar);
            selectedCar = Instantiate(Resources.Load<GameObject>("FBX_Models/" + PlayerPrefs.GetString("car")), transform.position, transform.rotation, transform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movingEnabled = true;
        }

        if (movingEnabled)
        {
            timer += Time.deltaTime;
            DisplayTime();
            currentSpeed += acceleration * Time.deltaTime;
            rb.AddForce(-transform.up * DownForceValue * rb.velocity.magnitude);
            ShowInfoScreen.SetActive(false);
        }

        transform.Translate(currentSpeed * Time.deltaTime * Vector3.forward);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        int milliseconds = Mathf.FloorToInt((timer * 1000) % 1000);
        string timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        int time = minutes * 360 + seconds * 60 + milliseconds;
        timerText.SetText("Timer: " + timeString);
        PlayerPrefs.SetInt("Timer", time);
        PlayerPrefs.SetString("Time", timeString);
    }
}
