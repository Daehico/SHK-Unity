using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private Vector3 _target;

    private void Start()
    {
        ChangeTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            ChangeTarget();
    }

    private void ChangeTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
