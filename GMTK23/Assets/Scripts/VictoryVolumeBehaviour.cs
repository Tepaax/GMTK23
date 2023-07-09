using UnityEngine;

public class VictoryVolumeBehaviour : MonoBehaviour
{
    [SerializeField]
    private PauseMenuController pauseMenuController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!pauseMenuController.VictoryCanvas.activeInHierarchy)
            {
                pauseMenuController.VictoryScreen();
            }
        }
    }
}
