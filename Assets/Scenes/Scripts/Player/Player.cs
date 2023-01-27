using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _health = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void ApplayDamage(int damage)
    {
        if (_health <= damage)
            Die();
            
        _health -= damage;
    }

    private void Die()
    {
        
    }
}
