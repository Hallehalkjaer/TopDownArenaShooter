using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHitable, IAgent
{
    [field: SerializeField]
    public EnemyDataSO enemyData;
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    public int Health { get; set; }
    public void Awake()
    {
        SetupEnemy();
    }

    private void SetupEnemy()
    {
        Health = enemyData.enemyMaxHealth;
       
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        OnGetHit?.Invoke();
        TakeDamage(damage);
    }

    public void TakeDamage(int incomingDamage)
    {
        Debug.Log("EnemyTakeDamage() Called" + incomingDamage);
        if (Health - incomingDamage <= 0)
        {
            Health -= incomingDamage;
            OnDie?.Invoke();
            StartCoroutine(WaitToDie());
        }
        else
            Health -= incomingDamage;
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
