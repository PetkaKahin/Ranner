using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class Let : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    public int Damage 
    {
        get => _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ApplayDamage(_damage);
        
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
