using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    public int Capacity 
    { 
        get => _capacity; 
        set 
        { 
            if (value < 0) 
                _capacity = value; 
        } 
    }

    public void InInicialize(GameObject prefab, Transform transform)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.First(s => s.activeSelf == false);

        return result != null;       
    }
}
