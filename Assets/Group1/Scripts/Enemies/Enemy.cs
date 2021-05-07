using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : CollectableItems
{
    public override void Collect(Player player)
    {
        Destroy(gameObject);
    }
}
