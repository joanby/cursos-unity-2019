using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;

    [SerializeField]
    private int currentHealth;
    public int Health{
        get{
            return currentHealth;
        }
        set{
            if(value < 0){
                currentHealth = 0;
            }else{
                currentHealth = value;
            }
        }
    }

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer _characterRenderer;

    public int expWhenDefeated;

    private QuestEnemy quest;
    private QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>();
        UpdateMaxHealth(maxHealth);
        quest = GetComponent<QuestEnemy>();
        questManager = FindObjectOfType<QuestManager>();
    }

    public void DamageCharacter(int damage){
        SFXManager.SharedInstance.PlaySFX(SFXType.SoundType.HIT);

        Health -= damage;
        if(Health <= 0){

            if(gameObject.tag.Equals("Enemy")){
                GameObject.Find("Player").
                          GetComponent<CharacterStats>().
                          AddExperience(expWhenDefeated);
                questManager.enemyKilled = quest;
            }

            if(gameObject.name.Equals("Player")){
                SFXManager.SharedInstance.PlaySFX(SFXType.SoundType.DIE);
                //TODO: implementar Game Over
            }

            gameObject.SetActive(false);
        }
        if(flashLength>0){
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
            flashActive = true;
            flashCounter = flashLength;
        }
    }

    public void UpdateMaxHealth(int newMaxHealth){
        maxHealth = newMaxHealth;
        Health = maxHealth;
    }

    void ToggleColor(bool visible){
        _characterRenderer.color = new Color(_characterRenderer.color.r,
                                             _characterRenderer.color.g,
                                             _characterRenderer.color.b,
                                             (visible ? 1.0f : 0.0f));
    }

    private void Update()
    {
        if(flashActive){
            flashCounter -= Time.deltaTime;
            if(flashCounter > flashLength * 0.66f){
                ToggleColor(false);
            }else if (flashCounter > flashLength*0.33f){
                ToggleColor(true);
            }else if(flashCounter > 0){
                ToggleColor(false);
            }else{
                ToggleColor(true);
                flashActive = false;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlayerController>().canMove = true;
            }

        }
    }

}
