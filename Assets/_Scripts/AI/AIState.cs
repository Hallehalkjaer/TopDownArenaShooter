﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private EnemyAIBrain enemyBrain = null;
    [field: SerializeField]
    private List<AIAction> actions = null;
    [field: SerializeField]
    private List<AITransition> transitions = null;


    private void Awake()
    {
        enemyBrain = transform.root.GetComponent <EnemyAIBrain>();

    }
    
    public void UpdateState()
    {
        
        foreach (var transition in transitions)
        {
            bool result = false;
            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeDecision();
                if (result == false)
                    break;
                
            }
            if (result)
            {
                if (transition.PositiveResult!= null)
                {
                    enemyBrain.ChangeToState(transition.PositiveResult);
                    return;
                }
            }
            else
            {
                if (transition.NegativeResult != null)
                {
                    enemyBrain.ChangeToState(transition.NegativeResult);
                    return;
                }
            }
            foreach (var action in actions)
            {
                action.TakeAction();
            }
        }
    }

}
