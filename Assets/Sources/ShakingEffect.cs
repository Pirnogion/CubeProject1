using UnityEngine;

public class ShakingEffect : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _impulse = 2.5f;

    public void Shake()
    {
        _rigidbody.AddForce(Vector3.up * _impulse, ForceMode.Impulse);
        _rigidbody.AddTorque(Random.onUnitSphere * _impulse, ForceMode.Impulse);
    }
}
