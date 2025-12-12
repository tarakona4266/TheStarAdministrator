using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionAudioController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip buildSuccess1;
    [SerializeField] AudioClip buildSuccess2;
    [SerializeField] AudioClip buildSuccess3;
    [SerializeField] AudioClip buildFailed;
    List<AudioClip> clips = new();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clips.Add(buildSuccess1);
        clips.Add(buildSuccess2);
        clips.Add(buildSuccess3);
    }

    public void PlaySound(bool success)
    {
        audioSource.Stop();
        if (success)
        {
            var rand = Random.Range(0, 3);
            audioSource.clip = clips[rand];
        }
        else
        {
            audioSource.clip = buildFailed;
        }
        audioSource.Play();
    }
}
