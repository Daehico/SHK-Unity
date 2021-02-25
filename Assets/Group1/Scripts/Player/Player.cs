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

    private void OnEnable()
    {
        foreach(var _enemy in _enemies)
        {
            _enemy.EnemyKilled += RemoveEnemy;
        }
    }

    private void Update()
    {
        if (_enemies.Count == 0)
            GameOver();
    }

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    public void BoostSpeed(float duration)
    {
        _boostSpeedDuration += duration;
        _playerMove.UpSpeed();
    }

    private IEnumerator StartTimer()
    {
        _boostSpeedDuration -= Time.deltaTime;
        if(_boostSpeedDuration <= 0)
        {
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
