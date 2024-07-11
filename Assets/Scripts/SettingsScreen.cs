using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsScreen : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        // Initialize sliders with current volume levels
        float masterVolume, musicVolume, sfxVolume;
        audioMixer.GetFloat("MasterVolume", out masterVolume);
        audioMixer.GetFloat("MxVolume", out musicVolume);
        audioMixer.GetFloat("SFXVolume", out sfxVolume);

        masterSlider.value = masterVolume;
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MxVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
