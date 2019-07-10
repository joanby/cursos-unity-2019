using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySecondScript : MonoBehaviour
{

    //Constantes
    public const float PI = 3.14159265f;
    //Solo lectura
    public readonly int numberOfEnemies;

    MySecondScript(){
        numberOfEnemies = 5;
    }


    public bool AttackEnemy(int damage) { return true; }
    public bool AttackEnemy(string player) { return true; }
    public bool AttackEnemy(float damage) { return true; }
    public bool AttackEnemy(float damage, string player) { return true};
    public void AttackEnemy(){}
    public float AttackEnemy(bool hello) { return 5.0f; }

    private void Start()
    {
       AttackEnemy();
        AttackEnemy(true);
        AttackEnemy(5.0f);
    }
}
