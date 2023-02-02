using UnityEngine;

public class Let : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _bonus;
    [SerializeField] private Score _score;

    public int Damage 
    {
        get => _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplayDamage(_damage);
            _score.AddScore(_bonus);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
