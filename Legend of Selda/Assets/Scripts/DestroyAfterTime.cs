using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy;


    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    /*private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if(timeToDestroy<0){
            Destroy(gameObject);
        }
    }*/


}
