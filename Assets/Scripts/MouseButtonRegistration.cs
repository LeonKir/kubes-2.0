using UnityEngine;

public class MouseButtonRegistration : MonoBehaviour
{
    public bool IsLeftMouseButtonDown()
    {
        const int MouseButton = 0;

        return Input.GetMouseButtonDown(MouseButton);
    }
}