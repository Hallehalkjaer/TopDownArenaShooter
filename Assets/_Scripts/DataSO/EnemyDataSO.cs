using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemies/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    
    //not implemented yet WEAPONDATA for enemies
    /*[field: SerializeField]
    public EnemyWeaponDataSO enemyWeaponData { get; set; }*/
    [field: SerializeField]
    public MovementDataSo movementData;
    public float tempSpeed;
    public float FrenzyMovementSpeed { get { tempSpeed = movementData.maxSpeed; return tempSpeed * 2; } }
    [field: SerializeField]
    public int enemyMaxHealth { get; private set; }

    //AI?!?! need implementation maybe
    /*[field: SerializeField]
     *public EnemyBehaviourDataSO enemyBehaviourData{get;set;}*/

    

}
