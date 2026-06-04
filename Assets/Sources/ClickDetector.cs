using System;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _sourceCamera;

    public event Action<RaycastHit> Clicked;

    private void Update()
    {
        if (_inputReader.GetIsClick())
        {
            var pos = _inputReader.GetMousePosition();
            var ray = _sourceCamera.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Clicked.Invoke(hit);
            }
        }
    }
}
