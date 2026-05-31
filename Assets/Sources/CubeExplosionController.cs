using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosionController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private int _generation = 0;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;
    [SerializeField] private float _explosionProbability = 1.0f;
    [SerializeField] private float _explosionProbabilityFactor = 0.5f;
    [SerializeField] private float _localScaleFactor = 0.5f;
    [SerializeField] private float _clickImpactImpulse = 2.5f;
    [SerializeField] private float _replicateExplosionImpulse = 15.0f;

    private void Awake()
    {
        if (_generation++ > 0)
        {
            Initialize();
        }
    }

    private void OnMouseDown()
    {
        ApplyImpact();

        if (Random.value < _explosionProbability)
        {
            Replicate();
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        _explosionProbability *= _explosionProbabilityFactor;
        transform.localScale *= _localScaleFactor;

        if (_meshRenderer.material != null)
        {
            _meshRenderer.material.color = Random.ColorHSV();
        }
    }

    private void Replicate()
    {
        int count = Random.Range(_minCount, _maxCount);

        for (int i = 0; i < count; ++i)
        {
            var instance = Instantiate(gameObject);
            var rigidbody = instance.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                ApplyExplosionTo(rigidbody);
            }
        }
    }

    private void ApplyImpact()
    {
        _rigidBody.AddForce(Vector3.up * _clickImpactImpulse, ForceMode.Impulse);
        _rigidBody.AddTorque(Random.onUnitSphere * _clickImpactImpulse, ForceMode.Impulse);
    }

    private void ApplyExplosionTo(Rigidbody rigidbody)
    {
        var direction = GetExplosionDirection();
        rigidbody.AddForce(direction * _replicateExplosionImpulse, ForceMode.Impulse);
    }

    private Vector3 GetExplosionDirection()
    {
        var raw = Random.onUnitSphere;
        return new Vector3(raw.x, Mathf.Abs(raw.y), raw.z);
    }
}
