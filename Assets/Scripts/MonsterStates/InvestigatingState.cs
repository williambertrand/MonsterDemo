using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigatingState : State
{

    private Animator animator;
    private Transform target;
    private float attackRange;
    public InvestigatingState(Monster monster, StateMachine stateMachine, Animator animator, float attackRange) : base(monster, stateMachine)
    {
        this.animator = animator;
        this.attackRange = attackRange;
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }


    public override void Enter()
    {
        base.Enter();
        animator.SetTrigger("Walk_Cycle_1");
        animator.speed = 1.25f;
        monster.navAgent.SetDestination(target.position);
    }
}
