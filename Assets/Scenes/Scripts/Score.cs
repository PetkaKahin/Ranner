using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private float _timeBetwwenAddScore;
    [SerializeField] private float _amountAddScore;

    private static int _score = 0;
    private float _timer = 0;

    public static event UnityAction<int> ChangeScore;

    private void Start()
    {
        ChangeScore?.Invoke(_score);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeBetwwenAddScore)
        {
            _timer = 0;
            _score++;
            ChangeScore?.Invoke(_score);
        }
    }

    public void AddScore(int amount)
    {
        if (amount > 0)
        {
            _score += amount;
            ChangeScore?.Invoke(_score);
        } 
    }
}