﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        // Assign health property to our enemy health
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}