using System;
using UnityEngine;

public class LocalScaleModificator : MonoBehaviour
{
    [SerializeField] private float _localScaleFactor = 0.5f;

    public float Value => transform.localScale.x;

    public event Action<float> Changed;

    public void Modify()
    {
        transform.localScale *= _localScaleFactor;
        Changed?.Invoke(Value);
    }
}
