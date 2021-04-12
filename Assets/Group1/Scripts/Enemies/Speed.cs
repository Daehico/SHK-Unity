using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider),typeof(SpriteRenderer))]
public class Speed : CollectableItems
{
    [SerializeField] private float _duration;

    private float _curentTime;

    public override void Collect(Player player)
    {
        player.BoostSpeed(_duration);
        StartCoroutine(StartTimer(player));
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private IEnumerator StartTimer(Player player)
    {
        yield return new WaitForSeconds(_duration);
        player.UnBoostSpeed();
        Destroy(gameObject);      
    }
}
