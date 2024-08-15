using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionData : MonoBehaviour
{
    [field: SerializeField]
    public bool Attack { get; set; }
    [field: SerializeField]
    public bool FrenzyStarted { get; set; }
    [field: SerializeField]
    public bool TargetInRange { get; set; }

    [field: SerializeField]
    public bool Arrived { get; set; }
}
