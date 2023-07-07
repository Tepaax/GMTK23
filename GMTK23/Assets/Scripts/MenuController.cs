using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Slider VolumeSlider;
    [SerializeField]
    private TMP_Text VolumeSliderText;
    [SerializeField]
    private TMP_Text TitleText;

    private float timer;
    private float originalSize;
    private int counter;
    private bool captureSize = true;
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
     
    }
}
