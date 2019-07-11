using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* ENUMERADOS
     * enum PlayerAction: byte { Attack, Defend , Fire , Jump };
     * PlayerAction action = PlayerAction.Attack;*/

    //Variables o propiedades
    public float moveSpeed = 5f;
    public float rotateSpeed = 60f;
    public float jumpSpeed = 5f;

    private float currentMoveSpeed, currentRotateSpeed;

    private float hInput, vInput;

    private Rigidbody _rb;


    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;

    private CapsuleCollider _col;

    public GameObject bullet;
    public Transform shootPoint;
    public float bulletSpeed = 100f;

    private GameManager gameManager;

    //Delegados y Eventos
    public delegate void JumpEvent();
    public event JumpEvent playerJump;




    //Métodos

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        currentMoveSpeed = moveSpeed;
        currentRotateSpeed = rotateSpeed;

        _col = GetComponent<CapsuleCollider>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Fire2")>0.5)//El get axis irá entre 0 y 1
        {
            currentMoveSpeed = moveSpeed / 2.0f;
            currentRotateSpeed = rotateSpeed / 2.0f;
        }else{
            currentMoveSpeed = moveSpeed;
            currentRotateSpeed = rotateSpeed;
        }


        // Cálculo de la velocidad (a partir del hardware)
        hInput = Input.GetAxis("Horizontal")*currentRotateSpeed;
        vInput = Input.GetAxis("Vertical")*currentMoveSpeed;

        /*//Forma de mover al personaje SIN usar el motor de físicas
        // S = v * t * i
        this.transform.Translate( vInput*Time.deltaTime* Vector3.forward);
        this.transform.Rotate(hInput * Time.deltaTime * Vector3.up);
        */

        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,
                                               shootPoint.position,
                                               shootPoint.rotation) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = shootPoint.forward * bulletSpeed;
        }


        if(IsOnTheGround() && Input.GetKeyDown(KeyCode.Space)){
            _rb.AddForce(Vector3.up * jumpSpeed,ForceMode.Impulse);
            playerJump();
        }

    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);


        // S = S0 + v*t
        _rb.MovePosition(this.transform.position +
                         this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    /// <summary>
    /// Comprueba si el personaje está tocando el suelo
    /// </summary>
    /// <returns><c>true</c>, si está tocando el suelo, 
    /// <c>false</c> si no.</returns>
    bool IsOnTheGround(){
        //Calculo 
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
                                            _col.bounds.min.y,
                                            _col.bounds.center.z);
        bool onTheGround = Physics.CheckCapsule(_col.bounds.center,
                                                capsuleBottom,
                                                distanceToGround,
                                                groundLayer,
                                                QueryTriggerInteraction.Ignore);

        return onTheGround;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy"){
            gameManager.HP--;
        }
    }
}
