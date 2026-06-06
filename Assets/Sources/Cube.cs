using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private VariableProbability _replicationProbability;
    [SerializeField] private LocalScaleModificator _localScaleModificator;
    [SerializeField] private ColorModificator _colorModificator;
    
    [SerializeField] private ScatteringEffect _scatteringEffect;
    [SerializeField] private ExplosionEffect _explosionEffect;

    public bool CanReplicate()
    {
        return _replicationProbability.IsOccurred();
    }

    public void OnReplicationPerformed()
    {
        _replicationProbability.Modify();
        _localScaleModificator.Modify();
        _colorModificator.ModifyRandomly();

        _scatteringEffect.PushAway();
    }

    public void OnReplicationFailed()
    {
        _explosionEffect.Explode();
    }
}
