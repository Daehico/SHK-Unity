using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CollectableItems : MonoBehaviour
{
    public event UnityAction<CollectableItems> ItemCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            ItemCollected?.Invoke(this);
            Collect(player);
        }
    }

    public abstract void Collect(Player player);

}
