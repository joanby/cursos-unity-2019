using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float speed = 1.5f;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public bool isWalking = false;
    public bool isTalking;

    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 4.0f;
    private float waitCounter;

    private Vector2[] walkingDirections = {
        Vector2.up, Vector2.down, Vector2.left, Vector2.right
    };
    private int currentDirection;

    public BoxCollider2D villagerZone;

    private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        isTalking = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(isTalking){
            isTalking = dialogueManager.dialogueActive;
            StopWalking();
            return;
        }

        if(isWalking){
            if(this.transform.position.x < villagerZone.bounds.min.x ||
               this.transform.position.x > villagerZone.bounds.max.x ||
               this.transform.position.y < villagerZone.bounds.min.y ||
               this.transform.position.y > villagerZone.bounds.max.y){
                StopWalking();
            }
            _rigidbody.velocity = walkingDirections[currentDirection] * speed;
            walkCounter -= Time.fixedDeltaTime;
            if(walkCounter<0){
                StopWalking();
            }
        }else{
            _rigidbody.velocity = Vector2.zero;
            waitCounter -= Time.fixedDeltaTime;
            if(waitCounter < 0){
                StartWalking();
            }
        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("Walking", isWalking);
        _animator.SetFloat("Horizontal", walkingDirections[currentDirection].x);
        _animator.SetFloat("Vertical", walkingDirections[currentDirection].y);
    }

    public void StartWalking(){
        currentDirection = Random.Range(0, walkingDirections.Length);
        isWalking = true;
        walkCounter = walkTime;
    }

    public void StopWalking(){
        isWalking = false;
        waitCounter = waitTime;
        _rigidbody.velocity = Vector2.zero;
    }
}
