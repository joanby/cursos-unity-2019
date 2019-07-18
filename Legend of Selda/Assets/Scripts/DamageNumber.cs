using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float damageSpeed;
    public float damagePoints;

    public Text damageText;
    public TMP_Text damageTextPro;

    public Vector2 direction = new Vector2(1,0);
    public float timeToChangeDirection = 1;
    public float timeToChangeDirectionCounter = 1;

    // Update is called once per frame
    void Update()
    {
        timeToChangeDirectionCounter -= Time.deltaTime;
        if(timeToChangeDirectionCounter < timeToChangeDirection/2){
            direction *= -1;
            timeToChangeDirectionCounter += timeToChangeDirection;
        }

        if (damageText != null)
        {
            damageText.text = "" + damagePoints;
        }

        if (damageTextPro != null)
        {
            damageTextPro.text = "" + damagePoints;
        }

        this.transform.position = new Vector3(
            this.transform.position.x + direction.x*damageSpeed*Time.deltaTime,
            this.transform.position.y + damageSpeed * Time.deltaTime,
            this.transform.position.z
        );

        this.transform.localScale = this.transform.localScale * (1 - Time.deltaTime/10);
    }
}
