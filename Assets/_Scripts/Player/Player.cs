using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHitable
{
    public int Health { get;set; }
    public UnityEvent OnDie { get; set; }
    private AgentMovement AgentMovement;
    public UnityEvent OnGetHit { get; set; }

    public void GetHit(int damage, GameObject damageDealer)
    {
        OnGetHit?.Invoke();
        TakeDamage(damage);
    }

    public void TakeDamage(int incomingDamage)
    {

        Debug.Log("PlayerTakeDamage() Called" + incomingDamage);
        if (Health - incomingDamage <= 0)
        {
            Health -= incomingDamage;
            OnDie?.Invoke();
            StartCoroutine(WaitToDie());
        }
        else
            Health -= incomingDamage;
    }

    private string WaitToDie()
    {
        throw new NotImplementedException();
    }
}

