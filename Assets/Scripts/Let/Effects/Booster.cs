using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]

public class Booster : MonoBehaviour
{
    [SerializeField] private LetMoveHeandler _letMoveHeandler;
    [SerializeField] private string frameName;
    [SerializeField] private float _addSpeed;

    private AnimationsBooster _animation;

    private void Start()
    {
        _animation = GameObject.Find(frameName).GetComponent<AnimationsBooster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _animation.StartAnimation();
            _letMoveHeandler.AddLetsSpeed(_addSpeed);
        }
    }
}
