using UnityEngine;
using UnityEngine.SceneManagement;

public class WallBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // @TODO: Add explosion / crash sound here
        }
    }
}
