using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<CollectableItems> _collectableItems = new List<CollectableItems>();
    [SerializeField] private GameObject _gameOver;

    private void GameOver()
    {
        _gameOver.SetActive(true);
    }

    public void RemoveEnemyFromList(CollectableItems item)
    {
        _collectableItems.Remove(item);
        if (_collectableItems.Count == 0)
            GameOver();
    }
}
