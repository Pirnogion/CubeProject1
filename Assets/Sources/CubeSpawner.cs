using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private const float HalfSize = 2.0f;

    [SerializeField] private Cube _cubeSample;
    [SerializeField] private BoxCollider _collider;

    [SerializeField] private int _initialCount = 10;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;

    private void Start()
    {
        Spawn(_cubeSample);
    }

    public List<Cube> Replicate(Cube sample)
    {
        var count = Random.Range(_minCount, _maxCount);
        var instances = new List<Cube>(count);

        for (int i = 0; i < count; ++i)
        {
            instances.Add(Instantiate(sample));
        }

        return instances;
    }

    public void Destroy(Cube instance)
    {
        Destroy(instance.gameObject);
    }

    private List<Cube> Spawn(Cube sample)
    {
        var instances = new List<Cube>(_initialCount);

        for (int i = 0; i < _initialCount; ++i)
        {
            var position = GetRandomPointInCollider(_collider);
            var rotation = Random.rotationUniform;

            instances.Add(Instantiate(sample, position, rotation));
        }

        return instances;
    }

    private Vector3 GetRandomPointInCollider(BoxCollider collider)
    {
        var center = collider.bounds.center;
        var size = collider.bounds.size;

        float randomX = Random.Range(-size.x / HalfSize, size.x / HalfSize);
        float randomY = Random.Range(-size.y / HalfSize, size.y / HalfSize);
        float randomZ = Random.Range(-size.z / HalfSize, size.z / HalfSize);

        return center + new Vector3(randomX, randomY, randomZ);
    }
}
