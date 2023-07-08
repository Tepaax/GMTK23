using UnityEngine;
using UnityEngine.SceneManagement;

public class KillVolumeBehaviour : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // @TODO: Show widget on screen
        }
    }
}
