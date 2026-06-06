using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private ClickDetector _clickDetector;

    private void OnEnable()
    {
        _clickDetector.Clicked += OnCubeClicked;
    }

    private void OnDisable()
    {
        _clickDetector.Clicked -= OnCubeClicked;
    }

    private void OnCubeClicked(RaycastHit hit)
    {
        if (!hit.collider.TryGetComponent(out Cube instance))
        {
            return;
        }

        if (instance.CanReplicate())
        {
            var replicas = _cubeSpawner.Replicate(instance);

            foreach (var replica in replicas)
            {
                replica.OnReplicationPerformed();
            }

            _cubeSpawner.Destroy(instance);
        }
        else
        {
            instance.OnReplicationFailed();
            _cubeSpawner.Destroy(instance);
        }
    }
}
