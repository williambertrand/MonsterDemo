using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{

    private Animator animator;
    private Transform target;
    private float attackRange;
    public ChasingState(Monster monster, StateMachine stateMachine, Animator animator, float attackRange) : base(monster, stateMachine)
    {
        this.animator = animator;
        this.attackRange = attackRange;
    }

    public override void Enter()
    {
        base.Enter();
        animator.SetTrigger("Walk_Cycle_1");
        animator.speed = 1.25f;
        Debug.Log("CHASING ENTER");
        monster.navAgent.SetDestination(Player.Instance.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
        animator.speed = 1.0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!monster.navAgent.pathPending && monster.navAgent.remainingDistance < attackRange)
        {
            stateMachine.ChangeState(monster.attackingSM);
        }
        else
        {
            monster.navAgent.SetDestination(Player.Instance.transform.position);
            //Debug.Log(monster.navAgent.remainingDistance);
        }
    }

    public override string ToString()
    {
        return "Chasing";
    }
}
