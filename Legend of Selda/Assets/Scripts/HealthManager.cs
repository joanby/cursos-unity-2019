using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;

    [SerializeField]
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMaxHealth(maxHealth);
    }

    public void DamageCharacter(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            gameObject.SetActive(false);
        }
    }

    public void UpdateMaxHealth(int newMaxHealth){
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
