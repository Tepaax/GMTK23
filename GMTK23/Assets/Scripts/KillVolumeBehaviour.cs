using UnityEngine;
using UnityEngine.SceneManagement;

public class KillVolumeBehaviour : MonoBehaviour
{
    [SerializeField]
    private PauseMenuController pauseMenuController;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!pauseMenuController.DeathCanvas.activeInHierarchy)
            {
                pauseMenuController.DeathScreen();

            }
        }
    }
}
