using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
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
            AddLetsSpeed(_addSpeedAfterTime);
            _timer = 0;
        }
    }

    public void AddLetsSpeed(float speed)
    {
        _letMover.AddSpeed(speed);
    }
}
