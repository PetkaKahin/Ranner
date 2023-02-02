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

    public void ApplayDamage(int damage)
    {
        if (_health <= damage)
            Die();

        _health -= damage;
        HealthUpdate?.Invoke(_health);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
