using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVolumeController : MonoBehaviour
{

    public enum AudioType { MUSIC, SFX };
    public AudioType type;

    private AudioSource audioSource;
    private float currentAudioLevel;

    [Range(0, 2)]
    public float defaultAudioLevel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetAudioLevel(float newAudioLevel){
        if(audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }
        currentAudioLevel = defaultAudioLevel * newAudioLevel;
        audioSource.volume = currentAudioLevel;
    }
}
