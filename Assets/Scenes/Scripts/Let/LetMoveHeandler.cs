using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetMoveHeandler : MonoBehaviour
{
    [SerializeField] private LetMover _letMover;

    [SerializeField] private float _startSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _addSpeedAfterTime;
    [SerializeField] private float _timeBettwenChangeSpeed;


    private float _timer = 0;

    private void Start()
    {
        _letMover.ChangeStartSpeed(_startSpeed);
        _letMover.ChangeMaxSpeed(_maxSpeed);
        _letMover.ChangeMinSpeed(_minSpeed);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeBettwenChangeSpeed)
        {
            _letMover.AddSpeed(_addSpeedAfterTime);
            _timer = 0;
        }
    }
}
