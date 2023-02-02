using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Booster : MonoBehaviour
{
    [SerializeField] LetMoveHeandler _letMoveHeandler;
    [SerializeField] float _addSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _letMoveHeandler.AddLetsSpeed(_addSpeed);
        }
    }
}
