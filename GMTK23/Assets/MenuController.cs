using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Slider VolumeSlider;
    [SerializeField]
    private TMP_Text VolumeSliderText;
    [SerializeField]
    private TMP_Text TitleText;
    [SerializeField]
    private TMP_Dropdown ResolutionDropDown;
    [SerializeField]
    private Toggle FullScreenToggle;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("");
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
                    Screen.SetResolution(1920, 1080, FullScreenToggle.isOn);
                    break;
                }
            case 2:
                {
                    Screen.SetResolution(1280, 720, FullScreenToggle.isOn);
                    break;
                }
            case 3:
                {
                    Screen.SetResolution(800, 600, FullScreenToggle.isOn);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
}
