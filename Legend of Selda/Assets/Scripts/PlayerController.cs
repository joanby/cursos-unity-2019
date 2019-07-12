using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //S = V*t
        if(Mathf.Abs(Input.GetAxisRaw(AXIS_H))>0.2f){
            Vector3 translation = new Vector3(
                Input.GetAxisRaw(AXIS_H) * speed * Time.deltaTime, 0, 0);
            this.transform.Translate(translation);
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            Vector3 translation = new Vector3(0, 
                Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);
            this.transform.Translate(translation);
        }
    }
}
