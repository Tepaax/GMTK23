using UnityEngine;

public class SandBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private bool slowDown = false;

    // Update is called once per frame
    void Update()
    {
        if (slowDown == true && target != null)
        {
            target.GetComponent<Rigidbody>().velocity *= 0.1f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            target = other.gameObject;
            slowDown = true;
        }
    }
}
