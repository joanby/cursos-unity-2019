using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hará la espada")]
    public int damage;

    public string weaponName;

    public GameObject bloodAnim;
    public GameObject canvasDamage;
    private GameObject hitPoint;

    private CharacterStats stats;

    private void Start()
    {
        hitPoint = transform.Find("Hit Point").gameObject;
        stats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy")){

            CharacterStats enemyStats = collision.gameObject.GetComponent<CharacterStats>();

            float plaFac = (1 + stats.strengthLevels[stats.level] / CharacterStats.MAX_STAT_VAL);
            float eneFac = (1 - enemyStats.defenseLevels[enemyStats.level] / CharacterStats.MAX_STAT_VAL);

            int totalDamage = (int)(damage * eneFac * plaFac);

            if(Random.Range(0,CharacterStats.MAX_STAT_VAL)<stats.accuracyLevels[stats.level]){
                if (Random.Range(0, CharacterStats.MAX_STAT_VAL) < enemyStats.luckLevels[enemyStats.level])
                {
                    totalDamage = 0;
                }
                else
                {
                    totalDamage *= 5;
                }
            }

            if (bloodAnim != null && hitPoint!=null)
            {
                Destroy(Instantiate(bloodAnim,
                            hitPoint.transform.position,
                            hitPoint.transform.rotation), 0.5f);
            }


            var clone = (GameObject)Instantiate(canvasDamage,
                                                 hitPoint.transform.position,
                                                 Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;

            collision.gameObject.
                     GetComponent<HealthManager>().
                     DamageCharacter(totalDamage);
        }
    }


}
