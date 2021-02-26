using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<CollectableItems> _enemies = new List<CollectableItems>();
    [SerializeField] private GameObject _gameOver;
    private float _boostSpeedDuration;
    private PlayerMove _playerMove;
    private bool _timer;

    private void OnEnable()
    {
        foreach(var _enemy in _enemies)
        {
            _enemy.EnemyKilled += RemoveEnemy;
        }
    }

    private void Start()
    {
        _timer = false;
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (_enemies.Count == 0)
            GameOver();
        if (_timer == true)
            StartCoroutine(StartTimer());
    }

    public void BoostSpeed(float duration)
    {
        _boostSpeedDuration += duration;
        _playerMove.UpSpeed();
        _timer = true;
    }

    private IEnumerator StartTimer()
    {
        _boostSpeedDuration -= Time.deltaTime;
        if(_boostSpeedDuration <= 0)
        {
            _playerMove.DownSpeed();
            _timer = false;
            StopCoroutine(StartTimer());     
        }
        yield return null;
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
    }

    private void RemoveEnemy(CollectableItems enemy)
    {
        enemy.EnemyKilled -= RemoveEnemy;
        _enemies.Remove(enemy);
    }
}
