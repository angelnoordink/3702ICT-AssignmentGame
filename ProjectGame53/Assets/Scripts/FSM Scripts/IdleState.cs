using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour {
   float timer;
   Transform player;
   UnityEngine.AI.NavMeshAgent agent;
   FieldOfView view;
   float viewRadius;
   float viewAngle;
   bool isInSight;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      timer = 0;
      player = GameObject.FindGameObjectWithTag("Player").transform;
      view = animator.GetComponent<FieldOfView>();
      agent = animator.GetComponent<NavMeshAgent>();
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      timer += Time.deltaTime;
      bool isInSight = CanSeePlayer(view.viewRadius, view.viewAngle, agent);

      if (timer > 5) {
         animator.SetBool("isPatrolling", true);
      }
   
      if(isInSight) {
         animator.SetBool("isChasing", true);
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

   public bool CanSeePlayer(float viewRadius, float viewAngle, UnityEngine.AI.NavMeshAgent agent){
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
