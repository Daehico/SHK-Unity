using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : CollectableItems
{
    [SerializeField] private Player _player;
    [SerializeField] private float _duration;

    public override void Collect()
    {
        _player.BoostSpeed(_duration);
        Destroy(gameObject);
    }

}
