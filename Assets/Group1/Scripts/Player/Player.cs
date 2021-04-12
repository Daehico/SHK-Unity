using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<CollectableItems> _collectableItems = new List<CollectableItems>();
    [SerializeField] private GameObject _gameOver;
    private float _boostSpeedDuration;
    private PlayerMove _playerMove;
    private int _countOfBosters;
    private float _curentTime;

    private void Start()
    {
        _countOfBosters = 0;
        _playerMove = GetComponent<PlayerMove>();
    }

    public void BoostSpeed(float duration)
    {
        _countOfBosters++;
        _playerMove.UpSpeed(_countOfBosters);
    }

    public void UnBoostSpeed()
    {
        _countOfBosters--;
        _playerMove.DownSpeed();
    }

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
