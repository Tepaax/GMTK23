using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource BackGroundMusic = null;
    [SerializeField]
    private AudioSource BackGroundSounds = null;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {

            BackGroundMusic.volume = PlayerPrefs.GetFloat("Volume") * 0.01f;
            BackGroundSounds.volume = PlayerPrefs.GetFloat("Volume") * 0.01f;
        }
    }
    public void UpdateVolumeGlobalAudio()
    {
        BackGroundMusic.volume = PlayerPrefs.GetFloat("Volume") * 0.01f;
        BackGroundSounds.volume = PlayerPrefs.GetFloat("Volume") * 0.01f;
    }
    public void MuteSounds()
    {
        BackGroundMusic.mute = !BackGroundMusic.mute;
        BackGroundSounds.mute = !BackGroundSounds.mute;
    }
}
