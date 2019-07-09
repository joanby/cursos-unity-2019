using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            //El ítem desaparece porque el player lo ha recogido
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Objeto recolectado");
        }
    }
}
