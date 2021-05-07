using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CollectableItems : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            RemoveEnemyFromList(player);
            Collect(player);
        }
    }

    private void RemoveEnemyFromList(Player player)
    {
        player.RemoveEnemyFromList(this);
    }

    public abstract void Collect(Player player);
}
