using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory<T> where T: Character
{
    private T _item;
    public T Item{
        get{
            return _item;
        }

        set{
            _item = value;
        }
    }

    public Inventory(){
        Debug.Log("Inventario creado");
    }

    public void SomeMethod(T someParameter){
        Debug.Log("Me ha llegado un objeto");
    }

    public void SetItem (T newItem){
        Item = newItem;
    }
}
