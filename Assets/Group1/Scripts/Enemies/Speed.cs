using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : CollectableItems
{
    [SerializeField] private float _duration;

    public override void Collect()
    {
        Player.BoostSpeed(_duration);
        Destroy(gameObject);
    }
}
