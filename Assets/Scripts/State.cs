using System.Collections;
using System.Collections.Generic;

public abstract class State
{

    protected Monster monster;
    protected StateMachine stateMachine;

    protected State(Monster monster, StateMachine stateMachine)
    {
        this.monster = monster;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        DisplayOnUI(UIManager.Alignment.Left);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }

    public override string ToString()
    {
        return "State";
    }
    protected void DisplayOnUI(UIManager.Alignment alignment)
    {
        //UIManager.Instance.Display(this, alignment);
    }
}
