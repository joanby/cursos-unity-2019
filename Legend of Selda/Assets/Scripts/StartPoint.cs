using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

	private PlayerController player;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;

    public string uuid;


    // Start is called before the first frame update
    void Start()
    {


        player = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();

        if (!player.nextUuid.Equals(uuid)){
            return;
        }


        player.transform.position = this.transform.position;
        theCamera.transform.position = new Vector3(transform.position.x,
                                               transform.position.y,
                                                theCamera.transform.position.z);

        player.lastMovement = facingDirection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
