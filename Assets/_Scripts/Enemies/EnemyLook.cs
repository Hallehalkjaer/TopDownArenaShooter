using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : AgentLookDirection
{
    public override void AimObject(Vector3 targetPosition)
    {
        var aimDirection = (Vector3)targetPosition - transform.position;
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }
}
