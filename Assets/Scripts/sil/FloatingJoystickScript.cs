using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class FloatingJoystickScript : MonoBehaviour
{
    public RectTransform joyStickObj;
    public RectTransform Knob;

    private void Awake()
    {
        joyStickObj = GetComponent<RectTransform>();
    }
}
