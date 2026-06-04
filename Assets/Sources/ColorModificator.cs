using UnityEngine;

public class ColorModificator : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    public void ModifyRandomly()
    {
        if (_meshRenderer.material != null)
        {
            _meshRenderer.material.color = Random.ColorHSV();
        }
    }
}
