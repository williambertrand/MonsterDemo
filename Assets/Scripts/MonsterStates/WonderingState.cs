using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderingState : State
{

    // Destination for wandering
    private Vector3 navDest;
    private Animator animator;

    public WonderingState(Monster monster, StateMachine stateMachine, Animator animator) : base(monster, stateMachine)
    {
        this.animator = animator;
    }

    private Vector3 GetNewWonderDest()
    {
        //Get random point within bounds of "level"
        float randX = Random.Range(-30, 30);
        float randz = Random.Range(-30, 30);
        Vector3 d = new Vector3(randX, 0.5f, randz);
        return d;
    }

    public override void Enter()
    {
        base.Enter();
        animator.SetTrigger("Walk_Cycle_2");
        monster.navAgent.SetDestination(GetNewWonderDest());
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!monster.navAgent.pathPending && monster.navAgent.remainingDistance < 0.75f)
        {
            stateMachine.ChangeState(monster.idleSM);
        }
    }

    public override string ToString()
    {
        return "Wondering";
    }
}
