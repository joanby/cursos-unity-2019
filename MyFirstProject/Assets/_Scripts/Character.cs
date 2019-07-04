using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Weapon
{
    public string name;
    public int damage;

    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
    public void PrintWeaponStats()
    {
        Debug.LogFormat("Arma: {0} - {1} daño", this.name, this.damage);
    }

}



public class Character
{
    public string name;
    public int exp = 0;

    public Character()
    {
        name = "Antonio Banderas";
    }

    public Character(string name)
    {
        this.name = name;
    }

    public Character(string name, int exp)
    {
        this.name = name;
        this.exp = exp;
    }

    public void PrintCharacterStats()
    {
        Debug.LogFormat("Heroe: {0} - {1} EXP", this.name, this.exp);
    }
}