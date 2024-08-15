using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/BulletData")]
public class BulletDataSO : ScriptableObject
{
    [field: SerializeField]
    public GameObject bulletPrefab { get; set; }
    [field: SerializeField]
    public float Friction { get; internal set; }
    [field: SerializeField]
    [field: Range(0,100)]
    public float BulletSpeed { get; internal set; }
    [field: SerializeField]
    public bool Bounce { get; set; }

    [field: SerializeField]
    public bool PierceHitable;

    [field: SerializeField]
    public bool IsRayCast;

    [field: SerializeField]
    public GameObject ImpactObstaclePrefab { get; set; }

    [field: SerializeField]
    public GameObject ImpactEnemyPrefab { get; set; }

    [field: SerializeField]
    [field: Range(1, 20)]
    public float KnockbackPower { get; set; } = 1;
    [field: SerializeField]
    [field: Range(0.1f, 1f)]
    public float KnockbackDelay { get; set; } = 0.1f;


    public int Damage { get; set; }



}
