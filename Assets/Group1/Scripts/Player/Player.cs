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
    private int _countOfBosters;

    private void OnEnable()
    {
        foreach (var _enemy in _enemies)
        {
            _enemy.ItemCollected += RemoveEnemy;
        }
    }

    private void Start()
    {
        _countOfBosters = 0;
        _playerMove = GetComponent<PlayerMove>();
    }

    public void BoostSpeed(float duration)
    {
        _boostSpeedDuration = duration;   
        _countOfBosters++;
        StartCoroutine(StartTimer());
        _playerMove.UpSpeed(_countOfBosters);
    }

    private IEnumerator StartTimer()
    {
        while(_countOfBosters != 0)
        {
            _boostSpeedDuration -= Time.deltaTime;
            if (_boostSpeedDuration <= 0)
            {
                _countOfBosters--;
                _playerMove.UpSpeed(_countOfBosters);
            }
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(StartTimer());
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
    }

    private void RemoveEnemy(CollectableItems enemy)
    {
        enemy.ItemCollected -= RemoveEnemy;
        _enemies.Remove(enemy);
        if (_enemies.Count == 0)
            GameOver();
    }
}
