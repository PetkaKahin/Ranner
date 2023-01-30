using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdaptation : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawner;
    [SerializeField] private Transform _destroyer;

    [SerializeField] private float _addUnitsPositionPlayer;
    [SerializeField] private float _addUnitsPositionSpawner;
    [SerializeField] private float _addUnitsPositionDestroyer;

    private Camera _camera;

    private void Start()
    {
        Invoke("RepositionObjects", 0.1f);
    }

    private void RepositionObjects()
    {
        _camera = GetComponent<Camera>();

        _addUnitsPositionPlayer -= _camera.orthographicSize;
        _addUnitsPositionSpawner += _camera.orthographicSize;
        _addUnitsPositionDestroyer -= _camera.orthographicSize;

        Debug.Log(_camera.orthographicSize);

        _player.position = new Vector3(0f, _addUnitsPositionPlayer, 0f);
        _spawner.position = new Vector3(0f, _addUnitsPositionSpawner, 0f);
        _destroyer.position = new Vector3(0f, _addUnitsPositionDestroyer, 0f);
    }
}
