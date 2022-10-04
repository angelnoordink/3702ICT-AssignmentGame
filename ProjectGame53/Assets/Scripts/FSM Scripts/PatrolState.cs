using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour {
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    FieldOfView view;
    Transform player;
    float viewRadius;
    float viewAngle;
    bool isInSight;
    // float chaseRange = 3.5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        timer = 0; 

        // Find Waypoints for this specific guard
        if (animator.transform.name == "SecurityGuard1") {
            GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
            foreach (Transform t in go.transform) {
                wayPoints.Add(t);
            }
        }
        if (animator.transform.name == "SecurityGuard2") {
            GameObject go = GameObject.FindGameObjectWithTag("WayPoints2");
            foreach (Transform t in go.transform) {
                wayPoints.Add(t);
            }
        }
        if (animator.transform.name == "SecurityGuard3") {
            GameObject go = GameObject.FindGameObjectWithTag("WayPoints3");
            foreach (Transform t in go.transform) {
                wayPoints.Add(t);
            }
        }

        view = animator.GetComponent<FieldOfView>();
        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        Debug.Log(animator.transform.name);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (agent.remainingDistance <= agent.stoppingDistance){
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

        bool isInSight = CanSeePlayer(view.viewRadius, view.viewAngle, agent);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        timer += Time.deltaTime;

        if (timer > 10) {
            animator.SetBool("isPatrolling", false);
        }

        if (isInSight) {
            animator.SetBool("isChasing", true);
        } 
    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        agent.SetDestination(agent.transform.position);
        // animator.SetBool("isPatrolling", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       // Implement code that sets up animation IK (inverse kinematics)
    }

    public bool CanSeePlayer(float viewRadius, float viewAngle, NavMeshAgent agent){
        RaycastHit hit;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 rayDirection = player.transform.position - agent.transform.position;

    
        if((Vector3.Angle(rayDirection, agent.transform.forward)) <= viewAngle * 0.5f){ // Detect if player is within the field of view
            if (Physics.Raycast (agent.transform.position, rayDirection, out hit, viewRadius)) {
                if (hit.transform.tag == "Player") {
                    // Debug.Log("Can see player");
                    return true;
                } else{
                    // Debug.Log("Can not see player");
                    return false;
                }
            } else { return false;}
        } else { return false; }
    }
}
