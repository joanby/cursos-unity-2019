using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").
                                GetComponent<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            //El ítem desaparece porque el player lo ha recogido
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Objeto recolectado");
            gameManager.Items++;
        }
    }
}
