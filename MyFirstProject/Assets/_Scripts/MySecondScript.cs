using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySecondScript : MonoBehaviour
{

    //Constantes
    public const float PI = 3.14159265f;
    //Solo lectura
    public readonly int numberOfEnemies;

    MySecondScript()
    {
        numberOfEnemies = 5;
    }


    public bool AttackEnemy(int damage) { return true; }
    public bool AttackEnemy(string player) { return true; }
    public bool AttackEnemy(float damage) { return true; }
    public bool AttackEnemy(float damage, string player) { return true; }
    public void AttackEnemy() { }
    public float AttackEnemy(bool hello) { return 5.0f; }

    private void Start()
    {
        AttackEnemy();
        AttackEnemy(true);
        AttackEnemy(5.0f);


        /*Inventory<Weapon> i = new Inventory<Weapon>();
        i.SetItem(new Weapon("Espada antigua", 20));

        Inventory<int> intI = new Inventory<int>();
        intI.SetItem(42);

        Inventory<string> students = new Inventory<string>();
        students.SetItem("Antonio Banderas");

        Inventory<Transform> wp = new Inventory<Transform>();
        wp.SetItem(GameObject.Find("Player").transform);
        */

        Inventory<Archer> a = new Inventory<Archer>();
    }


    // public class SomeGenericClass<T>{
    // Esta clase está preparada para colecciones genéricas del tipo T
    //}

    // SomeGenericClass<int> v = new SomeGenericClass<int>();


    //DELEGADOS
    //public delegate returnType NameOfTheDelegate(int param1, string param2...);
    //public DelegateName someDelegate = MyMethod;
    //public void MyMethod(...){
    //      ...
    //}

    //EVENTOS
    // public event EventDelegate eventInstance; 
    // public delegate void EventDelegate(int param1, string param2...)

    //someClass.eventInstance += EventHandler;
    //public void EventHandler(int param1, string param2...)
    //someClass.eventInstance -= EventHandler;

    //EXCEPTION
    public void ValidateUserEmail(string email){
        if(!email.Contains("@")){
            throw new System.ArgumentException("Email Invalid");
        }
    }
}
