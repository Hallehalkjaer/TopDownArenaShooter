using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    public GameObject weaponPrefab;
    [field: SerializeField]
    public BulletDataSO BulletData { get; set; }
    [field: SerializeField]
    [field: Range(1, 100)]
    public int AmmoCapacity { get; set; } = 100;
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Damage { get; set; }

    [field: SerializeField]
    public bool AutomaticFire { get; set; }
    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; }
    [field: SerializeField]
    [field: Range(0, 10)]
    public float SpreadAngle { get; set; } = 5;

    [field: SerializeField]
    private bool multiBulletShoot = false;
    [field: SerializeField]
    [field: Range(1,10)]
    private int bulletCount = 1;
    internal int GetBulletCountToSpawn()
    {
        if (multiBulletShoot)
        {
            return bulletCount;
        }return 1;
    }
}
