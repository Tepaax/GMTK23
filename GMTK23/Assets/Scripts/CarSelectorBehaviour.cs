using UnityEngine;

public class CarSelectorBehaviour : MonoBehaviour
{
    private GameObject[] cars = null;
    private int currentIndex = 0;
    private GameObject car = null;

    void Start()
    {
        cars = new GameObject[20];
        cars = Resources.LoadAll<GameObject>("FBX_Models");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectPreviousCar();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SelectNextCar();
        }
    }

    private void SelectPreviousCar()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = cars.Length - 1;
        }

        SelectCar();
    }

    private void SelectNextCar()
    {
        currentIndex++;
        if (currentIndex >= cars.Length)
        {
            currentIndex = 0;
        }

        SelectCar();
    }

    private void SelectCar()
    {
        // Destroy the current car if it exists
        if (car != null)
        {
            Destroy(car);
        }

        // Instantiate the new car and set it as the current car
        car = Instantiate(cars[currentIndex], transform.position, transform.rotation);
    }

    
}
