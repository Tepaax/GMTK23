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
    private TMP_Text TitleText = null;
    [SerializeField]
    private TMP_Dropdown ResolutionDropDown  =null;
    [SerializeField]
    private Toggle FullScreenToggle = null;
    private void Start()
    {
        Screen.SetResolution(800, 600, false);
        if (PlayerPrefs.HasKey("Volume"))
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        VolumeSlider.value = 50.0f;
        AdjustVolume();
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
    public void ResolutionChangeRequested()
    {
        switch (ResolutionDropDown.value)
        {
            case 1:
                {
                  Screen.SetResolution(800, 600, FullScreenToggle.isOn);
                  break;
                }
            case 2:
                {
                    Screen.SetResolution(1280, 720, FullScreenToggle.isOn);
                    break;
                }
            case 3:
                {
                   Screen.SetResolution(1920, 1080, FullScreenToggle.isOn);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
}
