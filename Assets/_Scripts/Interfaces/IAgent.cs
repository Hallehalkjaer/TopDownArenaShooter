﻿using UnityEngine;
using UnityEngine.Events;

public interface IAgent
{
    int Health { get; set; }
    UnityEvent OnDie { get; set; }
    UnityEvent OnGetHit { get; set; }

    void TakeDamage(int incomingDamage);
}