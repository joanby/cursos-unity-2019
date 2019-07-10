using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;

    public Transform patrolRoute;

    [HideInInspector]
    public List<Transform> waypoints;

    [SerializeField]
    private int locationIndex = 0;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializeWaypoints();
        MoveToNextWaypoint();
    }

    void InitializeWaypoints(){
        foreach(Transform wp in patrolRoute){
            waypoints.Add(wp);
        }
    }


    void MoveToNextWaypoint(){
        if(waypoints.Count == 0)
        {
            return;
        }
        _agent.SetDestination(waypoints[locationIndex].position);
        //locationIndex = (locationIndex + 1)%waypoints.Count;
        locationIndex = Random.Range(0, waypoints.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador detectado - Voy a por ti!!!");
            _agent.SetDestination(player.position);
        }
    }

    private float currentDelay = 0.0f;
    public float maxDelay = 0.5f;

    private void Update()
    {
        if(_agent.remainingDistance < 0.5f && !_agent.pathPending){
            currentDelay += Time.deltaTime;
            if(currentDelay>maxDelay){
                currentDelay = 0.0f;
                MoveToNextWaypoint();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador fuera de rango, me vuelvo a patrullar");
        }
    }

}
