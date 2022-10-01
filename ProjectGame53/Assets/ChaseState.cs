using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour {
    NavMeshAgent agent;
    FieldOfView view;
    Transform player;
    float viewRadius;
    float viewAngle;
    bool isInSight;
    // float attackRange = 1;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        view = animator.GetComponent<FieldOfView>();
        agent.speed = agent.speed + 0.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        bool isInSight = CanSeePlayer(view.viewRadius, view.viewAngle, agent);

        if (isInSight) {
            agent.SetDestination(player.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
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
                    Debug.Log("Can see player");
                    return true;
                } else{
                    Debug.Log("Can not see player");
                    return false;
                }
            } else { return false;}
        } else { return false; }
    }
}
