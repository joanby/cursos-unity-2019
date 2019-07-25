using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    private List<GameObject> weapons;
    public int activeWeapon;

    private List<GameObject> armors;
    public int activeArmor;

    private List<GameObject> rings;
    public int activeRing1, activeRing2;

    public List<GameObject> GetAllWeapons(){
        return weapons;
    }

    public List<GameObject> GetAllArmors()
    {
        return armors;
    }

    public List<GameObject> GetAllRings()
    {
        return rings;
    }

    public WeaponDamage GetWeaponAt(int pos){
        return weapons[pos].GetComponent<WeaponDamage>();
    }

    public GameObject GetArmorAt(int pos)
    {
        return armors[pos];
    }

    public GameObject GetRingAt(int pos){
        return rings[pos];
    }

    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        foreach(Transform weapon in transform){
            weapons.Add(weapon.gameObject);
        }

        for (int i = 0; i < weapons.Count; i++){
            weapons[i].SetActive(false);
        }

        armors = new List<GameObject>();
        //TODO: rellenar con las armaduras del personaje

        rings = new List<GameObject>();
        //TODO: rellenar con los anillos

    }

    public void ChangeWeapon(int newWeapon){
    
        weapons[activeWeapon].SetActive(false);
        weapons[newWeapon].SetActive(true);
        activeWeapon = newWeapon;


        FindObjectOfType<UIManager>().
             ChangeAvatarImage(weapons[activeWeapon].
             GetComponent<SpriteRenderer>().sprite);

    }

}
