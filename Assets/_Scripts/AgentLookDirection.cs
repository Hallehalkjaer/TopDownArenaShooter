using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentLookDirection : MonoBehaviour
{
    protected float desiredAngle;
    
    public virtual void AimObject(Vector3 pointerPosition)
    {
        var aimDirection = (Vector3)pointerPosition - transform.position;
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
        
    } 
}
