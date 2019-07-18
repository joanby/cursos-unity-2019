using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hará la espada")]
    public int damage;

    public GameObject bloodAnim;
    public GameObject canvasDamage;
    private GameObject hitPoint;

    private void Start()
    {
        hitPoint = transform.Find("Hit Point").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy")){

            if (bloodAnim != null && hitPoint!=null)
            {
                Destroy(Instantiate(bloodAnim,
                            hitPoint.transform.position,
                            hitPoint.transform.rotation), 0.5f);
            }


            var clone = (GameObject)Instantiate(canvasDamage,
                                                 hitPoint.transform.position,
                                                 Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagePoints = damage;

            collision.gameObject.
                     GetComponent<HealthManager>().
                     DamageCharacter(damage);
        }
    }


}
