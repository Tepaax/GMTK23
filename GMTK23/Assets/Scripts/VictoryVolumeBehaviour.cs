using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryVolumeBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // @TODO: Show victory screen
        }
    }
}
