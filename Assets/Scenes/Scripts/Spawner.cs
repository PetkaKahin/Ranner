using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnObjects = new List<GameObject>();
    [SerializeField] private List<ObjectPool> _pools = new List<ObjectPool>();
    [SerializeField] private List<int> _changeSpawnObjects = new List<int>();
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    [SerializeField] private float _minSecondBetweenSpawned = 1f;
    [SerializeField] private float _maxSecondBetweenSpawned = 1f;

    private float _SecondBetweenSpawned;
    private float _timer = 0;

    private void Start()
    {
        _SecondBetweenSpawned = _maxSecondBetweenSpawned;
        for (int i = 0; i < _pools.Count; i++)
        {
            _pools[i].InInicialize(_spawnObjects[i], _pools[i].transform);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _SecondBetweenSpawned)
        {
            _timer = 0;
            _SecondBetweenSpawned = Random.Range(_minSecondBetweenSpawned, _maxSecondBetweenSpawned);

            RandomObjectSelectin();
        }
    }

    private void ActivateObject(GameObject prefab, Vector3 spawnPoint)
    {
        prefab.SetActive(true);
        prefab.transform.position = spawnPoint;
    }

    private void RandomObjectSelectin()
    {
        int maxChange = 0;

        foreach (var item in _changeSpawnObjects)
            if(item > maxChange)
                maxChange = item;

        int randomChage = Random.Range(0, maxChange + 1);

        for (int i = 0; i < _pools.Count; i++)
        {
            if (randomChage <= _changeSpawnObjects[i])
            {
                if (_pools[i].TryGetObject(out GameObject spawnObject))
                    ActivateObject(spawnObject, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position);

                break;
            }
        }  
    }
}
