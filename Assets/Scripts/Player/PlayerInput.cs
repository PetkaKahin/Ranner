using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class PlayerInput : MonoBehaviour
{ 
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _playerMover.TryMoveLeft();

        if (Input.GetKeyDown(KeyCode.D))
            _playerMover.TryMoveRight();
    }
}
