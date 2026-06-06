using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private LocalScaleModificator _localScaleModificator;

    [SerializeField] private float _upwardModifier = 0.5f;

    [SerializeField] private AnimationCurve _impulseCurve;
    [SerializeField] private AnimationCurve _radiusCurve;

    private float _impulse;
    private float _radius;

    private void Start()
    {
        UpdateDynamicParameters(_localScaleModificator.Value);
    }

    private void OnEnable()
    {
        _localScaleModificator.Changed += UpdateDynamicParameters;
    }

    private void OnDisable()
    {
        _localScaleModificator.Changed -= UpdateDynamicParameters;
    }

    public void Explode()
    {
        var position = transform.position;
        var colliders = Physics.OverlapSphere(position, _radius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                if (rigidbody != _rigidbody)
                {
                    rigidbody.AddExplosionForce(_impulse, position, _radius, _upwardModifier, ForceMode.Impulse);
                }
            }
        }
    }

    private void UpdateDynamicParameters(float scale)
    {
        _impulse = _impulseCurve.Evaluate(scale);
        _radius = _radiusCurve.Evaluate(scale);
    }
}
