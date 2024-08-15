﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{

    protected Rigidbody2D rigidBody2D;
    public override BulletDataSO BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidBody2D = GetComponent<Rigidbody2D>();
            rigidBody2D.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if(rigidBody2D != null && BulletData != null)
        {
            rigidBody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitable = collision.GetComponent<IHitable>();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(hitable);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle();
        }
        


    }

    private void HitEnemy(IHitable hitable)
    {
    
        hitable?.GetHit(BulletData.Damage, gameObject);
        if (!BulletData.PierceHitable)
        {
            Destroy(gameObject);
        }
    }
    private void HitObstacle()
    {
        if (!BulletData.PierceHitable)
        {
            Destroy(gameObject);
        }
    }
}
