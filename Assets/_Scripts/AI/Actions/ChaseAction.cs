using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        Debug.Log("chase");
        var direction = enemyBrain.Target.transform.position - transform.position;
        aiMovementData.Direction = direction.normalized;
        enemyBrain.Move(aiMovementData.Direction);
    }
}
