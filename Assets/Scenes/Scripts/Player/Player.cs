using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 10;

    public static event UnityAction<int> HealthUpdate;
    public static event UnityAction Died;

    private void Start()
    {
        HealthUpdate?.Invoke(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void ApplayDamage(int damage)
    {
        if (_health <= damage)
        {
            Die();
        }
        else
        {
            _health -= damage;
            HealthUpdate?.Invoke(_health);
        }
    }

    private void Die()
    {
        
    }
}
