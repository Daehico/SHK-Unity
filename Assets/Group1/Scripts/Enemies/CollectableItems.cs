using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CollectableItems : MonoBehaviour
{
    private Player _player;

    public Player Player => _player;

    public event UnityAction<CollectableItems> ItemCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _player = other.GetComponent<Player>();
            ItemCollected?.Invoke(this);
            Collect();
        }
    }

    public abstract void Collect();

}
