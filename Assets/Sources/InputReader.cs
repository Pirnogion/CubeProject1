using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const int LeftMouseButtonCode = 0;

    private bool _isClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonCode))
        {
            _isClick = true;
        }
    }

    public bool GetIsClick() => GetBoolAsTrigger(ref _isClick);
    public Vector3 GetMousePosition() => Input.mousePosition;

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}