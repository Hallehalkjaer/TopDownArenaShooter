﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData aiActionData;
    protected AIMovementData aiMovementData;
    protected EnemyAIBrain enemyBrain;

    private void Awake()
    {

    }
    private void Update()
    {
        aiActionData = transform.root.GetComponentInChildren<AIActionData>();
        aiMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyBrain = transform.root.GetComponentInChildren<EnemyAIBrain>();
    }

    public abstract bool MakeDecision();
}
