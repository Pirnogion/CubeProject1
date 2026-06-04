using UnityEngine;

public class VariableProbability : MonoBehaviour
{
    [SerializeField] private float _probability = 1.0f;
    [SerializeField] private float _probabilityFactor = 0.5f;

    public void Modify()
    {
        _probability *= _probabilityFactor;
    }

    public bool IsOccurred()
    {
        return Random.value < _probability;
    }
}
