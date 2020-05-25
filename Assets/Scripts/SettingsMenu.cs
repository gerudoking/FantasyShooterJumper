using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("musicVol", Mathf.Log10(volume) * 20);
    }
    public void SetSFX(float volume)
    {
        audioMixer.SetFloat("sfx", volume);
    }

}
