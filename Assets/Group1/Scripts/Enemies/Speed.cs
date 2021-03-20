using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        while (_curentTime < _duration)
        {
            _curentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        player.UnBoostSpeed();
        Destroy(gameObject);
        StopCoroutine(StartTimer(player));
    }

}
