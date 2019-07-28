using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController[] audios;

    [Range(0, 1)]
    public float maxVolumeLevel;

    [Range(0, 1)]
    public float currentVolumeLevel;

    // Start is called before the first frame update
    void Start()
    {
        audios = FindObjectsOfType<AudioVolumeController>();
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.SFX);
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.MUSIC);
    }

    public void ChangeGlobalAudioVolume(AudioVolumeController.AudioType type){
        if(currentVolumeLevel >= maxVolumeLevel){
            currentVolumeLevel = maxVolumeLevel;
        }

        foreach(AudioVolumeController ac in audios){
            if (ac.type == type)
            {
                ac.SetAudioLevel(currentVolumeLevel);
            }
        }
    }

    public void AudioChanged(Slider audioSlide){
        currentVolumeLevel = audioSlide.value;
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.MUSIC);
    }

    public void SFXChanged(Slider audioSlide)
    {
        currentVolumeLevel = audioSlide.value;
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.SFX);
    }
}
