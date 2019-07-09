using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador detectado - Voy a por ti!!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador fuera de rango, me vuelvo a patrullar");
        }
    }

}
