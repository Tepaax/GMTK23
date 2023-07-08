using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;
using Unity.VisualScripting;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Slider VolumeSlider = null;
    [SerializeField]
    private TMP_Text VolumeSliderText = null;
    [SerializeField]
    private TMP_Dropdown ResolutionDropDown  =null;
    [SerializeField]
    private Toggle FullScreenToggle = null;
    [SerializeField] 
    private Animator TitleTextAnimator = null;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Resolution"))
        {
            ResolutionDropDown.value = PlayerPrefs.GetInt("Resolution");
        }
        else
        {
            ResolutionDropDown.value = 0;
        }
        if (PlayerPrefs.HasKey("Volume"))
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            VolumeSlider.value = 50.0f;
        }
        FullScreenToggle.isOn = Screen.fullScreen;
        AdjustVolume();
        ResolutionChangeRequested();

      //  TitleTextAnimator.Play("Active", 0, 0.0f);
     
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AdjustVolume()
    {
        VolumeSliderText.SetText(VolumeSlider.value.ToString());
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);

    }
    public void ToggleFullScreenMode()
    {
        Screen.fullScreen = !Screen.fullScreen;
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
}
