using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";


    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
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

    private void LateUpdate()
    {
        _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
    }
}
