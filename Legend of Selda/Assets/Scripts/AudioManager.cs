using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTracks;
    public int currentTrack;
    public bool audioCanBePlayed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audioCanBePlayed){
            if(!audioTracks[currentTrack].isPlaying){
                audioTracks[currentTrack].Play();
            }
        }else{
            audioTracks[currentTrack].Stop();
        } 
    }

    public void PlayNewTrack(int newTrack){
        audioTracks[currentTrack].Stop();
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();
    }
}
