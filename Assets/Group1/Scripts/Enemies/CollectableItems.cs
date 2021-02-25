using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CollectableItems : MonoBehaviour
{
    public readonly Player player;

    public event UnityAction<CollectableItems> EnemyKilled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            InvokeEvent();
            Collect();
        }
    }

    private void InvokeEvent()
    {
        EnemyKilled?.Invoke(this);
    }

    public abstract void Collect();

}
