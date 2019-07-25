using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager sharedInstance = null;

    public static SFXManager SharedInstance {
        get{
            return sharedInstance;
        }
    }

    private void Awake()
    {
        if(sharedInstance != null && sharedInstance != this){
            Destroy(gameObject);
        }

        sharedInstance = this;
        DontDestroyOnLoad(gameObject);

        audios = new List<GameObject>();

        GameObject sounds = GameObject.Find("Sounds");
        foreach (Transform t in sounds.transform)
        {
            audios.Add(t.gameObject);
        }
    }


   

    private List<GameObject> audios;


    public AudioSource FindAudioSource(SFXType.SoundType type){
        foreach(GameObject g in audios){
            if(g.GetComponent<SFXType>().type == type){
                return g.GetComponent<AudioSource>();
            }
        }
        return null; //Esto no se ejecutará nunca
    }

    public void PlaySFX(SFXType.SoundType type){
        FindAudioSource(type).Play();
    }

}
