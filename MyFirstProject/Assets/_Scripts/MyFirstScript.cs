using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public Transform cameraTransform;
    public Light directionalLight;
    public Transform lightTransform;


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

        Paladin p = new Paladin();

        Paladin p2 = new Paladin("Juan Gabriel", sword);
        p2.PrintCharacterStats();

        Archer a = new Archer("Legolas", 
                              new Weapon("Arco de los bosques", 7)
                             );
        Magician m = new Magician("Gandalf");

        List<Character> party = new List<Character>();
        party.Add(p2);
        party.Add(a);
        party.Add(m);

        foreach( Character c in party){
            c.PrintCharacterStats();
        }

        //El script está en la cámara
        //Podemos consultar otros componentes de la cámara
        Transform theTransform = GetComponent<Transform>();
        Debug.Log(theTransform.position);
        Debug.Log(theTransform.rotation);

        Camera cam = GetComponent<Camera>();
        Debug.Log(cam.fieldOfView);

        GameObject myLight = GameObject.Find("Directional Light");
        Transform t = myLight.GetComponent<Transform>();
        Debug.Log("La luz está en: "+t.position);

        
    }


}