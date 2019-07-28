using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class Money : MonoBehaviour
{
    public int value;
    private MoneyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<MoneyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            manager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
