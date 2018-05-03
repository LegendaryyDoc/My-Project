using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {

    public enum AIStates
    {
        ChaseState,
        AttackState,
        DeathState,
    }

    public bool isAttacking;

    public AIStates CurrentState;

    public GameObject TargetPoint; //Point to move towards

    private NavMeshAgent agent;

    public float AttackRange = 10.0f;

    public Animator Anim;

    public Rigidbody RB;

    public float AttackDelay;

    public float SetAttackDelay;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>(); //Gets the component on the object that the script is attached to
        agent.SetDestination(TargetPoint.transform.position);
    }

    public void updateAnim(Animator AnimationController)
    {
        if (AnimationController != null)
        {
            var localVel = transform.InverseTransformDirection(agent.velocity);
            AnimationController.SetFloat("ForwardSpeed", localVel.z);
        }
    }


    public bool inAttackRange()
    {

        float DistanceToTarget = agent.remainingDistance;

        if (DistanceToTarget <= AttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void doChase(GameObject target)
    {
        if (target == null)
        {
            Debug.Log("Chase can Not Run Due To Null Reference of Target");
            return;
        }
        if (agent.isStopped) { agent.isStopped = false; }

        float DistanceToTarget = agent.remainingDistance;

        if (inAttackRange())
        {
            CurrentState = AIStates.AttackState;
            return;
        }
        agent.SetDestination(TargetPoint.transform.position);
    }

    public void doAttack(float DeltaTime)
    {
        if (agent.isStopped) { agent.isStopped = true; }

        if (!inAttackRange() && !isAttacking)
        {
            CurrentState = AIStates.ChaseState;
            return;
        }

        if(SetAttackDelay <= 0)
        {
            Anim.SetTrigger("Attack");
            isAttacking = true; 
            SetAttackDelay = AttackDelay;
        }

        agent.SetDestination(TargetPoint.transform.position);
    }

    public void doDeath(bool isDead)
    {

    }

    // Update is called once per frame
    void Update () {

        switch (CurrentState) //Current State = ...
        {
            case AIStates.ChaseState:
                doChase(TargetPoint);
                break;

            case AIStates.AttackState:
                doAttack(Time.deltaTime);
                break;

            case AIStates.DeathState:
                doDeath(false); //create death variabe to check
                break;
        }
        updateAnim(Anim);
        
               
		
	}
}
