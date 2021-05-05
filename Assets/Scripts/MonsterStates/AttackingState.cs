using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : State
{
    private Animator animator;
    public float attackTime;
    public float timeToAttack;
    public AttackingState(Monster monster, StateMachine stateMachine, Animator animator, float attackTime) : base(monster, stateMachine)
    {
        this.animator = animator;
        this.attackTime = attackTime;
    }

    public override void Enter()
    {
        base.Enter();
        //item = human.NextItem
        //Set destination position based on next item on "shopping" list
        timeToAttack = Time.time + attackTime;
        int num = Random.Range(1, 5);
        animator.SetTrigger("Attack_" + num);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= timeToAttack)
        {
            Debug.Log("Change to chasing!");
            stateMachine.ChangeState(monster.chasingSM);
            //int num = Random.Range(1, 5);
            //animator.SetTrigger("Attack_" + num);
            //timeToAttack = Time.time + attackTime;
        }
    }


    public override string ToString()
    {
        return "Attacking";
    }
}
