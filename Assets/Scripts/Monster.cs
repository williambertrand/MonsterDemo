using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monster : MonoBehaviour
{


    private StateMachine stateMachine;
    public string currentStateStr;
    #region StateDefs
    public IdleState idleSM;
    public WonderingState wonderingSM;
    public ChasingState chasingSM;
    public AttackingState attackingSM;
    public InvestigatingState investigatingSM;

    // public ChasingState chasingSM;
    // intim, attack
    #endregion

    private Animator anim;
    public NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

        stateMachine = new StateMachine();

        // create "machines" to handle each of the mosnter's states
        idleSM = new IdleState(this, stateMachine, anim);
        wonderingSM = new WonderingState(this, stateMachine, anim);
        chasingSM = new ChasingState(this, stateMachine, anim, 2.0f);
        attackingSM = new AttackingState(this, stateMachine, anim, 1.5f);
        investigatingSM = new InvestigatingState(this, stateMachine, anim, 1.5f);

        //TODO: Implenent Investigating state where monster goes over to a light 
        // Certain player actions could still transition monster from investigating to chasing

        // Set the starting state for the monster
        stateMachine.Initialize(idleSM);
    }

    // Update is called once per frame
    void Update()
    {
        // If this were a character statemachine for the player - we'd listen to input here....
        //stateMachine.CurrentState.HandleInput();
        stateMachine.CurrentState.LogicUpdate();
        currentStateStr = stateMachine.CurrentState.ToString();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(navAgent.destination, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stateMachine.ChangeState(chasingSM);
        }
        else
        {
            Debug.Log("Collision: xxx" + other.tag);
        }
    }


    public void OnLightOn(FloorLight l)
    {
        // Check distance 

        if (stateMachine.CurrentState == chasingSM) return;
        investigatingSM.SetTarget(l.transform);
        stateMachine.ChangeState(investigatingSM);
    }

}
