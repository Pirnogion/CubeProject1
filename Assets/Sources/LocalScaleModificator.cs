using UnityEngine;

public class LocalScaleModificator : MonoBehaviour
{
    [SerializeField] private float _localScaleFactor = 0.5f;

    public void Modify()
    {
        transform.localScale *= _localScaleFactor;
    }
}
