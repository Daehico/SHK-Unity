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
            player.RemoveEnemyFromList(this);
            Collect(player);
        }
    }

    public abstract void Collect(Player player);

}
