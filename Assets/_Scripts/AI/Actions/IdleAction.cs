using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        Debug.Log("idle");
        enemyBrain.Move(Vector2.zero);
    }
}