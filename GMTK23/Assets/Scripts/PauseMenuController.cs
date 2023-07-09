using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;
using Unity.VisualScripting;


public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu = null;
    public static bool gamePaused = false;
    [SerializeField]
    private Slider VolumeSlider = null;
    [SerializeField]
    private TMP_Text VolumeSliderText = null;
    [SerializeField]
    private TMP_Dropdown ResolutionDropDown = null;
    [SerializeField]
    private Toggle FullScreenToggle = null;
    [SerializeField]
    private GameObject ControlsMenu = null;
    [SerializeField]
    private AudioSource PauseMusic = null;
    [SerializeField]
    private AudioScript GlobalAudioScript = null;
    [SerializeField]
    private GameObject DeathCanvas = null;
    [SerializeField]
    private GameObject VictoryCanvas = null;
   
    private void Start()
    {
        if(PlayerPrefs.HasKey("Resolution"))
        {
            ResolutionDropDown.value = PlayerPrefs.GetInt("Resolution");
        }
        FullScreenToggle.isOn = Screen.fullScreen;
        if (PlayerPrefs.HasKey("Volume"))
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            VolumeSlider.value = 25.0f;
           
        }
        AdjustVolume();
        ResolutionChangeRequested();
    }
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
    private void DeathScreen()
    {
                pauseMenu.gameObject.SetActive(false);
                gamePaused = true;
                ControlsMenu.gameObject.SetActive(false);
                DeathCanvas.gameObject.SetActive(true);
                GlobalAudioScript.MuteSounds();
                Time.timeScale = 0;
                             
    }  private void VictoryScreen()
    {
                pauseMenu.gameObject.SetActive(false);
                gamePaused = true;
                ControlsMenu.gameObject.SetActive(false);
                DeathCanvas.gameObject.SetActive(false);
                VictoryCanvas.gameObject.SetActive(true);
                GlobalAudioScript.MuteSounds();
                Time.timeScale = 0;
                             
    }
    private void NextLevel()
    {
        VictoryCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void RestartLevel()
    {
        DeathCanvas.SetActive(false);
        VictoryCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

   private void PauseGame()
    {
        if (!VictoryCanvas.activeInHierarchy || !DeathCanvas.activeInHierarchy)
        {
            pauseMenu.gameObject.SetActive(true);
            gamePaused = true;
            ControlsMenu.gameObject.SetActive(false);
            GlobalAudioScript.MuteSounds();
            Time.timeScale = 0;
        }                   
    }
   public void ResumeGame()
    {
        if (!VictoryCanvas.activeInHierarchy || !DeathCanvas.activeInHierarchy)
        {

            pauseMenu.gameObject.SetActive(false);
            gamePaused = false;
            ControlsMenu.gameObject.SetActive(false);
            GlobalAudioScript.MuteSounds();
            Time.timeScale = 1;
        }
    }
    public void ToggleFullScreenMode()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

   public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
  public void AdjustVolume()
    {
        VolumeSliderText.SetText(VolumeSlider.value.ToString());
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
        PauseMusic.volume = VolumeSlider.value * 0.01f;
        GlobalAudioScript.UpdateVolumeGlobalAudio();


    }
    public void ResolutionChangeRequested()
    {
        switch (ResolutionDropDown.value)
        {
            case 0:
                {
                  Screen.SetResolution(800, 600, FullScreenToggle.isOn);
                    PlayerPrefs.SetInt("Resolution", 0);
                  break;
                }
            case 1:
                {
                    Screen.SetResolution(1280, 720, FullScreenToggle.isOn);

                    PlayerPrefs.SetInt("Resolution", 1);
                    break;
                }
            case 2:
                {
                    Screen.SetResolution(1920, 1080, FullScreenToggle.isOn);
                    PlayerPrefs.SetInt("Resolution", 2);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
    public void OpenControlsMenu()
    {
        if(ControlsMenu.gameObject.activeInHierarchy)
        {

            ControlsMenu.gameObject.SetActive(false);
        }
        else
        {
           
            ControlsMenu.gameObject.SetActive(true);    
        }
    }
}


