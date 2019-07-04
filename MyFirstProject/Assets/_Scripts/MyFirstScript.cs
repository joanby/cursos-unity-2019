using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    void Start()
    {
        Character hero = new Character();
        hero.PrintCharacterStats();//hero = "AB"

        Character hero2 = hero;
        hero2.PrintCharacterStats(); //hero2 = "AB"

        hero2.name = "Madonna"; 
        hero.PrintCharacterStats(); //hero = "M"
        hero2.PrintCharacterStats(); //hero2 = "M"


        Character heroine = new Character("Lara Croft");
        heroine.PrintCharacterStats();

        Weapon sword = new Weapon("Espada roma", 5);
        sword.PrintWeaponStats(); //sword = "ER"

        Weapon sword2 = sword;
        sword2.PrintWeaponStats(); //sword2 = "ER"

        sword2.name = "Excalibur";
        sword2.damage = 255;

        sword.PrintWeaponStats(); //sword = "ER"
        sword2.PrintWeaponStats(); //sword2 = "Ex"

    }


}