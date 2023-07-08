using UnityEngine;

public class CarSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cars = null;

    private int currentIndex = 0;
    [SerializeField]
    private GameObject car = null;
    [SerializeField]
    private Vector3 SpawnSize;
    [SerializeField]
    private PlayerController PlayerCar = null;
    void Start()
    {
        cars = new GameObject[20];
        cars = Resources.LoadAll<GameObject>("FBX_Models/");
        if(PlayerPrefs.HasKey("car"))
        {
            car = Resources.Load<GameObject>("FBX_Models/" + PlayerPrefs.GetString("car"));
        }
        else
        {
            car = Resources.Load<GameObject>("FBX_Models/truck");
        }
        car = Instantiate(car, transform.position, transform.rotation);
        car.transform.SetParent(transform, true);
        car.transform.localScale = SpawnSize;


                
    }

    private void Update()
    {
        if (Time.timeScale == 0)
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
        else
        {
            return;
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
        PlayerPrefs.SetString("car", car.name.Replace("(Clone)", null));
        car.transform.SetParent(transform, true);
        car.transform.localScale = SpawnSize;
        PlayerCar.ReinstantiateCar();
   }


}
