using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class MonsterConstants
{
    public static readonly float MIN_IDLE = 1.5f;
    public static readonly float MAX_IDLE = 3.5f;
}

public class IdleState : State
{

    private float timeToMove;
    private Animator anim;
    public IdleState(Monster monster, StateMachine stateMachine, Animator animator) : base(monster, stateMachine)
    {
        anim = animator;
    }

    public override void Enter()
    {
        base.Enter();
        //item = human.NextItem
        //Set destination position based on next item on "shopping" list
        timeToMove = Time.time + Random.Range(MonsterConstants.MIN_IDLE, MonsterConstants.MAX_IDLE);
        anim.SetTrigger("Rest_1");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= timeToMove)
        {
            stateMachine.ChangeState(monster.wonderingSM);
        }
    }

    public override string ToString()
    {
        return "Idle";
    }

}
