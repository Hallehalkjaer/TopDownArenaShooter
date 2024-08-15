using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [field: SerializeField]
    protected WeaponRenderer weaponRenderer;
    [field: SerializeField]
    protected Weapon weapon;

    private void Awake()
    {
        AssignWeapon();
    }

    private void AssignWeapon()
    {
        //WEaponrenderer is used to render weapons and make sure the sprite behaves proper to input (i dont think its needed when i use a static sprite)
        //weaponRenderer.GetComponentInChildren<SpriteRenderer>();
        
        weapon = GetComponentInChildren<Weapon>();
    }

    public void Shoot()
    {
        if(weapon != null)
            weapon.TryShooting();
    }
    public void StopShooting()
    {
        if(weapon != null)
            weapon.StopShooting();
    }
}
