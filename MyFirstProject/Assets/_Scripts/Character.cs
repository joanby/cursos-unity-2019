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

    public virtual void PrintCharacterStats()
    {
        Debug.LogFormat("Heroe: {0} - {1} EXP", this.name, this.exp);
    }

    private void Reset()
    {
        this.name = "Antonio Banderas";
        this.exp = 0;
    }

}


public class Paladin : Character
{

    public Weapon weapon;

    public Paladin() : base()
    {

    }

    public Paladin(string name, Weapon weapon) : base(name)
    {
        this.weapon = weapon;
    }


    public override void PrintCharacterStats(){
        Debug.LogFormat("Hola, soy el paladin {0} y llevo un(a) {1}",
                        this.name, this.weapon.name);
    }

}

public class Archer : Character
{

    Weapon arch;

    public Archer(string name, Weapon arch) : base(name)
    {
        this.arch = arch;
    }

    public override void PrintCharacterStats()
    {
        base.PrintCharacterStats();
        Debug.LogFormat("Llevo un(a) {0}", this.arch.name);
    }
}

public class Magician : Character
{

    Weapon staff;

    public Magician (string name): base(name)
    {
        this.staff = new Weapon("Vara de sauce", 25);
    }
}