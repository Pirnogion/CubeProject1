using UnityEngine;

public class ScatteringEffect : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _impulse = 15.0f;

    public void PushAway()
    {
        var direction = CalculateDirection();
        _rigidbody.AddForce(direction * _impulse, ForceMode.Impulse);
    }

    private Vector3 CalculateDirection()
    {
        var raw = Random.onUnitSphere;
        return new Vector3(raw.x, Mathf.Abs(raw.y), raw.z);
    }
}
