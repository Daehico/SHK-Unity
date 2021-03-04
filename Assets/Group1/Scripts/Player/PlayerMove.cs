using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _startSpeed;

    private void Start()
    {
        _startSpeed = _speed;
    }

    private void Update()
    {
      if(Input.GetAxis("Horizontal") != 0)
            transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime,0, 0);
        if (Input.GetAxis("Vertical") != 0)
            transform.Translate(0, Input.GetAxis("Vertical") * _speed * Time.deltaTime, 0);
    }

    public void UpSpeed(int countOfBoosters)
    {
        if (countOfBoosters == 0)
            DownSpeed();
        else
            _speed *= (2 + countOfBoosters);
    }

    public void DownSpeed()
    {
        _speed = _startSpeed;
    }
}
