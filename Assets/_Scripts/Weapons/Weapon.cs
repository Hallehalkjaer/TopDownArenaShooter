using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [field: SerializeField]
    protected GameObject muzzle;
    [field: SerializeField]
    [field: Range(0,100)]
    private int ammo = 100;
    [field: SerializeField]
    public WeaponDataSO weaponData;

    public int Ammo
    {
        get { return ammo; }
        set { ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity); }
    }
    public bool AmmoFull { get => Ammo >= weaponData.AmmoCapacity; }
    protected bool isShooting = false;

    [field: SerializeField]
    protected bool reloadCoroutine = false;

    [field: SerializeField]
    public UnityEvent OnShoot { get; set; }
    [field: SerializeField]
    public UnityEvent OnShootNoAmmo { get; set; }

    private void Start()
    {
        Ammo = weaponData.AmmoCapacity;
    }
    public void TryShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }
    //notgonna use reload i think
    public void Reload(int ammo)
    {
       
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && !reloadCoroutine)
        {
            Debug.Log("Shoot");
            if(Ammo > 0)
            {
                //Ammo--;
                //OnShoot?.Invoke();
                for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                    
                }

            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                
                return;
            }
            FinishShoot();
        }
    }

    private void FinishShoot()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if(weaponData.AutomaticFire == false)
        {
            StopShooting();
        }

    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {

        weaponData.BulletData.Damage = weaponData.Damage;
        var bulletPrefab = Instantiate(weaponData.BulletData.bulletPrefab, position, rotation);
        bulletPrefab.GetComponent<Bullet>().BulletData = weaponData.BulletData;
        
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, 270+spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }
}
