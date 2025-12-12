using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void SetMusicVolume(float soundLevel)
    {
        audioMixer.SetFloat("MusicVolumeParam", soundLevel);
    }

    public void SetEffectsVolume(float soundLevel)
    {
        audioMixer.SetFloat("EffectsVolumeParam", soundLevel);
    }
}
