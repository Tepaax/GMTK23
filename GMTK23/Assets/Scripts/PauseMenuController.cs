using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu = null;
    public static bool gamePaused = false;
    void Update()
    {
        //Toggle PauseMenu on/off
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
   public void PauseGame()
    {
                pauseMenu.gameObject.SetActive(true);
                gamePaused = true;
                Time.timeScale = 0;
 
    }
   public void ResumeGame()
    {
                pauseMenu.gameObject.SetActive(false);
                gamePaused = false;
                Time.timeScale = 1;       
    }
   public void ExitToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
