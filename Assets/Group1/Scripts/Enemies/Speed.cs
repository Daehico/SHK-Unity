using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider),typeof(SpriteRenderer))]
public class Speed : CollectableItems
{
    [SerializeField] private float _duration;

    private BoxCollider _boxColider;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _boxColider = GetComponent<BoxCollider>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Collect(Player player)
    {
        StartCoroutine(Boost(player));
        _boxColider.enabled = false;
        _spriteRenderer.enabled = false;
    }

    private IEnumerator Boost(Player player)
    {
        if (player.TryGetComponent(out PlayerMove _playerMove))
        {
            _playerMove.UpSpeed();
            yield return new WaitForSeconds(_duration);
           _playerMove.DownSpeed();
            Destroy(gameObject);
        }   
    }
}
