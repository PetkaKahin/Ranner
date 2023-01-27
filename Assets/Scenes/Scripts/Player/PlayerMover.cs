using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxLeftPosition;
    [SerializeField] private float _maxRightPosition;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void TryMoveLeft()
    {
        if(_targetPosition.x > _maxLeftPosition)
            SetNextPosition(-_step);
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _maxRightPosition)
            SetNextPosition(_step);
    }

    private void SetNextPosition(float step)
    {
        _targetPosition += new Vector3(step, 0f, 0f);
    }
}
