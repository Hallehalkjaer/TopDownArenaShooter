using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour, IAgentInput
{
    private bool hasFrenzied = false;
    private GameObject enemy;
    [field: SerializeField]
    public AIState CurrentState { get; set; }
    [field: SerializeField]
    public GameObject Target { get; set; }
    [field: SerializeField]
    public UnityEvent OnFireButtonHeld { get; set; }
    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnMovmentKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector3> OnPointerPositionChange { get; set; }
    //used this attribute as position to player but pretty sure we can just use onpointerpositionchanged
    //[field: SerializeField]
    //public UnityEvent<Vector2> OnPointerPlayerPositionChange { get; set; }

    public float originalSpeed;
    private void Awake()
    {
        Target = FindObjectOfType<Player>().gameObject;
        GetComponent<AgentMovement>().MovementData.maxSpeed = 2;
    }
    private void Update()
    {
        GetPlayerPosition();
        CurrentState.UpdateState();

        //obsolete but kept in comment because it might be good to keep in mind in future development
        //if (Target == null)
        //    OnMovmentKeyPressed?.Invoke(Vector2.zero);
        
    }
    public void Attack()
    {
        OnFireButtonHeld?.Invoke();
    }
    //missing  a parameter as targetPosition but using my target object instead maynbe doesnt work
    public void Move(Vector2 movementDirection)
    {
        //if(hasFrenzied )
        OnMovmentKeyPressed?.Invoke(movementDirection);
        OnPointerPositionChange?.Invoke(Target.transform.position);
    }
    public void Frenzy(Vector2 movementDirection)
    {
        if (!hasFrenzied)
        {
            enemy = GetComponentInParent<Enemy>().gameObject;

            GetComponent<AgentMovement>().MovementData.maxSpeed = GetComponent<Enemy>().enemyData.FrenzyMovementSpeed;
            
            hasFrenzied = true;
        }
        OnMovmentKeyPressed?.Invoke(movementDirection);
        OnPointerPositionChange?.Invoke(Target.transform.position);
    }

    private void GetPlayerPosition()
    {
        
        OnPointerPositionChange?.Invoke(Target.transform.position);
    }

    internal void ChangeToState(AIState state)
    {
        CurrentState = state;
    }
}
