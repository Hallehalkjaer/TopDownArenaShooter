using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenzyAction : AIAction
{
    public override void TakeAction()
    {
        Debug.Log("frenzy");
        var direction = enemyBrain.Target.transform.position - transform.position;
        aiMovementData.Direction = direction.normalized;
        enemyBrain.Frenzy(aiMovementData.Direction);
    }
}
