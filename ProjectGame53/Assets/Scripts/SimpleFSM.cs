using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;


public class SimpleFSM : MonoBehaviour 
{
    public enum FSMState
    {
        None,
        Patrol,
        Chase,
        Capture,
    }

    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float distanceThreshold = 1.0f;
    private Transform currentWaypoint;
    private Animator animator;

    private NavMeshAgent nav;

	// Current state that the NPC is reaching
	public FSMState curState;
     public float speed = 20.0f;

	protected Transform playerTransform;// Player Transform
    public float viewRadius;
    public LayerMask targetMask;

	// Ranges for chase and capture
	public float chaseRange = 5.0f;
	public float captureRange = 2.0f;
    public float captureStopRange = 1.0f;


    // Initialise
	void Start() {

        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator> ();

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        curState = FSMState.Patrol;

        // Get the target enemy(Player)
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        playerTransform = objPlayer.transform;

        if(!playerTransform) {
            print("Player doesn't exist.. Please add one with Tag named 'Player'");
        }

        

	}


    // Update each frame
    void Update() {
        switch (curState) {
            case FSMState.Patrol: UpdatePatrolState(); break;
            case FSMState.Chase: UpdateChaseState(); break;
            case FSMState.Capture: UpdateCaptureState(); break;
        }

        if (curState == FSMState.Patrol) {
            nav.destination = currentWaypoint.position;

            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold) {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                nav.destination = currentWaypoint.position;
            }
        }
    }

	// Patrol
    protected void UpdatePatrolState() {
        

        // Calculate Distance between player tank and target
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // If target is within chase distance, update state to Chase
        if (distance <= chaseRange) {
            curState = FSMState.Chase;
        }

    }


    // Chase State
    protected void UpdateChaseState() {
        // Check the distance with player tank
        // When the distance is near, transition to capture state
		float dist = Vector3.Distance(transform.position, playerTransform.position);
		if (dist < captureRange) {
            curState = FSMState.Capture;
        }
        // Go back to patrol is it become too far
        else if (dist >= chaseRange) {
			curState = FSMState.Patrol;
		}
		
	}
	

	// Capture State
    protected void UpdateCaptureState() {
		// Transitions
		// Check the distance with the player tank
        float dist = Vector3.Distance(transform.position, playerTransform.position);
		if (dist > captureRange) {
			curState = FSMState.Chase;
		}
        // Transition to patrol if the tank is too far
        else if (dist > chaseRange) {
			curState = FSMState.Patrol;
		}
        else if (dist <= captureStopRange) {
            // Enter captured events here
        }
    }
    

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, captureRange);

        Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, captureStopRange);
	}

}
