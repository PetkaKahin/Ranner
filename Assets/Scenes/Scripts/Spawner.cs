using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnObjects = new List<GameObject>();
    [SerializeField] private List<ObjectPool> _pools = new List<ObjectPool>();
    [SerializeField] private List<int> _changeSpawnObjects = new List<int>();
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    [SerializeField] private float _minDelaySecondSpawned = 1f;
    [SerializeField] private float _maxDelaySecondSpawned = 1f;
    [SerializeField] [Range(0.01f, 1f)] private float _spawnMaxSpeedDependency = 1f;

    [SerializeField] private LetMover _letMevor;

    private float _SecondBetweenSpawned;
    private float _timer = 0;

    private void Start()
    {
        _SecondBetweenSpawned = _maxDelaySecondSpawned;
        _startDitanceSecond = _letMevor.Speed * _maxDelaySecondSpawned;

        for (int i = 0; i < _pools.Count; i++)
        {
            _pools[i].InInicialize(_spawnObjects[i], _pools[i].transform);
        }

        CalculateChangeSpawn();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _SecondBetweenSpawned)
        {
            _timer = 0;
            _SecondBetweenSpawned = Random.Range(_minDelaySecondSpawned, _maxDelaySecondSpawned);
            _SecondBetweenSpawned = _maxDelaySecondSpawned;
            _maxDelaySecondSpawned = CalculateMaxDelaySecond(_letMevor.Speed);

            ActivateObject(RandomObjectSelectin(), _spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
        }
    }

    private void ActivateObject(GameObject prefab, Vector3 spawnPoint)
    {
        prefab.SetActive(true);
        prefab.transform.position = spawnPoint;
    }

    private int[] _changesSpawn;
    private int _change;
    private GameObject RandomObjectSelectin()
    {
        int randomChange = Random.Range(0, _change);
        
        for (int i = 0; i < _changesSpawn.Length; i++)
            if (_changesSpawn[i] > randomChange)
                if (_pools[i].TryGetObject(out GameObject spanwObject))
                    return spanwObject;

        return null;
    }

    private void CalculateChangeSpawn()
    {
        _changesSpawn = new int[_changeSpawnObjects.Count];

        _change = 0;

        foreach (var item in _changeSpawnObjects)
            _change += item;

        for (int i = 0; i < _changeSpawnObjects.Count; i++)
            for (int j = 0; j <= i; j++)
                _changesSpawn[i] += _changeSpawnObjects[j];
    }

    private float _startDitanceSecond;
    private float CalculateMaxDelaySecond(float speed)
    {
        float distanceSecond = speed * _maxDelaySecondSpawned;
        float speedFactor = distanceSecond / _startDitanceSecond;
        float maxDelaySecondSpawned = _maxDelaySecondSpawned / speedFactor;

        if (maxDelaySecondSpawned > _minDelaySecondSpawned)
            return maxDelaySecondSpawned / _spawnMaxSpeedDependency;

        return _minDelaySecondSpawned;
    }
}
